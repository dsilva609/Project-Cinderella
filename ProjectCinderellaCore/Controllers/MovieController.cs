using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Model.UI;
using ProjectCinderella.Model.Enums;
using System.Linq;

namespace ProjectCinderellaCore.Controllers
{
	public class MovieController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IMovieService _service;
		private readonly ITMDBService _tmdbService;
		private readonly IWishService _wishService;
		private const int NUM_MOVIES_TO_GET = 25;

		public MovieController(IUserContext user, IMovieService service, ITMDBService tmdbService, IWishService wishService)
		{
			_user = user;
			_service = service;
			_tmdbService = tmdbService;
			_wishService = wishService;
		}

		[HttpGet]
		public virtual ActionResult Index(string movieQuery, string filter, int? page)
		{
			if (string.IsNullOrWhiteSpace(movieQuery) && !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("movie-query")))
			{
				movieQuery = HttpContext.Session.GetString("movie-query");
				HttpContext.Session.SetString("movie-query", string.Empty);
			}

			ViewBag.Filter = (string.IsNullOrWhiteSpace(movieQuery) ? filter : movieQuery)?.Trim();

			var movies = _service.GetAll(string.Empty, ViewBag.Filter) as List<Movie>;
			var viewModel = new MovieViewModel
			{
				ViewTitle = "Movies/TV",
				Movies = movies?.ToPagedList(page ?? 1, NUM_MOVIES_TO_GET),
				PageSize = NUM_MOVIES_TO_GET,
			};

			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			var movie = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Details - {movie.Title}";
			return View(movie);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var model = HttpContext.Session.Get("movieResult") ?? new Movie { UserID = _user.GetUserID(), UserNum = _user.GetUserNum() };
			ViewBag.Title = "Create";
			HttpContext.Session.Set("movieResult", null);
			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(Movie movie)
		{
			if (!ModelState.IsValid) return View(movie);

			try
			{
				if (movie.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && movie.TimesCompleted == 0)
					movie.TimesCompleted = 1;
				movie.DateAdded = DateTime.UtcNow;
				SetTimeStamps(movie);

				this._service.Add(movie);
			}
			catch (Exception e)
			{
				ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Movie");
				return View(movie);
			}
			HttpContext.Session.Set("movie-query", null);

			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish")))
			{
				_wishService.Delete(Convert.ToInt32(HttpContext.Session.GetString("wishID")), _user.GetUserID());
				HttpContext.Session.Set("wish", null);
				HttpContext.Session.SetString("wishID", null);
				ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
			}
			ShowStatusMessage(MessageTypeEnum.success, "New Movie Added Successfully.", "Add Successful");
			return RedirectToAction("Index", "Movie");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			ViewBag.Title = $"Edit - {model.Title}";
			if (model.UserID != _user.GetUserID()) return RedirectToAction("Details", "Movie", (object) model.ID);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Movie movie)
		{
			if (!ModelState.IsValid) return View(movie);

			var existingMovies = _service.GetAll(_user.GetUserID());

			if (existingMovies.Count > 0 && existingMovies.Any(x => x.ID != movie.ID && x.Title == movie.Title && x.Type == movie.Type))
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A Movie of Title: {movie.Title}, Media Type: {movie.Type} already exists.",
					"Duplicate Movie");
				return View(movie);
			}

			if (movie.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed && movie.TimesCompleted == 0)
				movie.TimesCompleted = 1;
			if (movie.TimesCompleted > 0) movie.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			SetTimeStamps(movie);
			//TODO: make sure user id is the same so as not to change other users data
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.success, $"Movie of Title {movie.Title}, Media Type: {movie.Type} updated.", "Update Successful");
			return RedirectToAction("Index", "Movie");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			var model = _service.GetByID(id, _user.GetUserID());
			if (model.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This movie cannot be deleted by another user", "Delete Failure");
				return RedirectToAction("Index", "Movie");
			}

			_service.Delete(id, _user.GetUserID());

			ShowStatusMessage(MessageTypeEnum.success, "", "Movie Deleted Successfully");

			return RedirectToAction("Index", "Movie");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(MovieSearchModel searchModel)
		{
			if (!string.IsNullOrWhiteSpace(searchModel.Title)) searchModel.Title = searchModel.Title.Trim();
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("movie-query"))) searchModel.Title = HttpContext.Session.GetString("movie-query");
			if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("wish"))) searchModel.Title = HttpContext.Session.GetString("wish");

			if (Request.UrlReferrer?.LocalPath == "/Movie/Search" && string.IsNullOrWhiteSpace(searchModel.Title))
			{
				ShowStatusMessage(MessageTypeEnum.error, "Please enter search terms.", "Search Error");
				return View(searchModel);
			}

			if (!string.IsNullOrWhiteSpace(searchModel.Title))
			{
				searchModel.MovieResults = _tmdbService.SearchMovies(searchModel.Title);
				searchModel.TVShowResults = _tmdbService.SearchTV(searchModel.Title);
				foreach (var result in searchModel.MovieResults)
					result.poster_path = string.Format("https://image.tmdb.org/t/p/w300{0}", result.poster_path);

				foreach (var result in searchModel.TVShowResults)
					result.poster_path = string.Format("https://image.tmdb.org/t/p/w300{0}", result.poster_path);
			}
			ViewBag.Title = "Movie/TV Show Search";

			return View(searchModel);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult CreateFromSearchResult(int releaseID, bool isTvShow, int seasonNumber)
		{
			var movie = isTvShow ? _tmdbService.SearchTVShowByID(releaseID, seasonNumber) : _tmdbService.SearchMovieByID(releaseID);

			movie.UserID = _user.GetUserID();
			movie.UserNum = _user.GetUserNum();
			ViewBag.Title = "Create";

			HttpContext.Session.Set("movieResult", movie);

			return RedirectToAction("Create", "Movie");
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var movie = _service.GetByID(id, _user.GetUserID());
			movie.IsShowcased = true;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Title added to showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var movie = _service.GetByID(id, _user.GetUserID());
			movie.IsShowcased = false;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Title removed from showcase", "Showcase");
			return RedirectToAction("Index", "Showcase",(object) _user.GetUserNum());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult IncreaseCompletionCount(int id)
		{
			var movie = _service.GetByID(id, _user.GetUserID());

			if (movie.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This movie cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Movie");
			}

			movie.TimesCompleted += 1;
			movie.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.Completed;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Movie was updated.", "Update");
			return RedirectToAction("Index", "Movie");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult DecreaseCompletionCount(int id)
		{
			var movie = _service.GetByID(id, _user.GetUserID());

			if (movie.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This movie cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Movie");
			}

			if (movie.TimesCompleted > 0) movie.TimesCompleted -= 1;
			if (movie.TimesCompleted == 0) movie.CompletionStatus = ProjectCinderella.Model.Enums.CompletionStatus.NotStarted;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Movie was updated.", "Update");
			return RedirectToAction("Index", "Movie");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult AddToQueue(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This movie/TV show cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Movie");
			}

			if (game.IsQueued)
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This movie/TV show is already queued.", "Edit Failure");
				return RedirectToAction("Index", "Movie");
			}

			game.IsQueued = true;
			var currentHighestRank = _service.GetHighestQueueRank(_user.GetUserID());
			game.QueueRank = currentHighestRank + 1;

			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Movie/TV Show added to queue", "Queue");
			return RedirectToAction("Index", "Queue");
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult RemoveFromQueue(int id)
		{
			var game = _service.GetByID(id, _user.GetUserID());

			if (game.UserID != _user.GetUserID())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This movie/TV show cannot be edited by another user.", "Edit Failure");
				return RedirectToAction("Index", "Movie");
			}

			game.IsQueued = false;
			game.QueueRank = 0;

			_service.Edit(game);

			ShowStatusMessage(MessageTypeEnum.info, "Movie/TV Show removed from queue,", "Queue");
			return RedirectToAction("Index", "Queue");
		}
	}
}