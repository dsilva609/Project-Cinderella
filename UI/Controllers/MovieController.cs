using AutoMapper;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Models;
using CompletionStatus = BusinessLogic.Enums.CompletionStatus;

namespace UI.Controllers
{
	public partial class MovieController : ProjectCinderellaControllerBase
	{
		private readonly IMovieService _service;
		private readonly ITMDBService _tmdbService;
		private readonly IWishService _wishService;
		private const int NUM_MOVIES_TO_GET = 25;

		public MovieController(IMovieService service, ITMDBService tmdbService, IWishService wishService)
		{
			_service = service;
			_tmdbService = tmdbService;
			_wishService = wishService;
		}

		[HttpGet]
		public virtual ActionResult Index(string movieQuery, string filter, int? page)
		{
			if (string.IsNullOrWhiteSpace(movieQuery) && !string.IsNullOrWhiteSpace(Session["query"]?.ToString()))
			{
				movieQuery = Session["query"].ToString();
				Session["query"] = string.Empty;
			}

			ViewBag.Filter = (string.IsNullOrWhiteSpace(movieQuery) ? filter : movieQuery)?.Trim();

			var movies = _service.GetAll(User.Identity.GetUserId(), ViewBag.Filter) as List<Movie>;
			var viewModel = new MovieViewModel
			{
				ViewTitle = "Index",
				Movies = movies?.ToPagedList(page ?? 1, NUM_MOVIES_TO_GET),
				PageSize = NUM_MOVIES_TO_GET,
			};

			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			ViewBag.Title = "Details";
			var movie = _service.GetByID(id, User.Identity.GetUserId());

			return View(movie);
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			var model = Session["movieResult"] ?? new Movie { UserID = User.Identity.GetUserId() };
			ViewBag.Title = "Create";
			Session["movieResult"] = null;

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
				if (movie.CompletionStatus == CompletionStatus.Completed && movie.TimesCompleted == 0)
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
			Session["query"] = null;

			if (!string.IsNullOrWhiteSpace(Session["wish"]?.ToString()))
			{
				_wishService.Delete(Convert.ToInt32(Session["wishID"].ToString()), User.Identity.GetUserId());
				Session["wish"] = null;
				Session["wishID"] = null;
				ShowStatusMessage(MessageTypeEnum.info, "Wish list has been updated", "Wish list");
			}
			ShowStatusMessage(MessageTypeEnum.success, "New Movie Added Successfully.", "Add Successful");
			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			ViewBag.Title = "Edit";
			var model = _service.GetByID(id, User.Identity.GetUserId());

			if (model.UserID != User.Identity.GetUserId())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This item cannot be edited by another user.", "Edit Failure");
				return RedirectToAction(MVC.Movie.Index());
			}

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Movie movie)
		{
			if (!ModelState.IsValid) return View(movie);

			var existingMovies = _service.GetAll(User.Identity.GetUserId());

			if (existingMovies.Count > 0 && existingMovies.Any(x => x.ID != movie.ID && x.Title == movie.Title && x.Type == movie.Type))
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A Game of Title: {movie.Title}, Media Type: {movie.Type} already exists.",
					"Duplicate Movie");
				return View(movie);
			}

			if (movie.CompletionStatus == CompletionStatus.Completed && movie.TimesCompleted == 0)
				movie.TimesCompleted = 1;
			SetTimeStamps(movie);
			//TODO: make sure user id is the same so as not to change other users data
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.success, $"Movie of Title {movie.Title}, Media Type: {movie.Type} updated.", "Update Successful");
			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			var model = _service.GetByID(id, User.Identity.GetUserId());
			if (model.UserID != User.Identity.GetUserId())
			{
				ShowStatusMessage(MessageTypeEnum.error, "This game cannot be deleted by another user", "Delete Failure");
				return RedirectToAction(MVC.Game.Index());
			}

			_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Movie Deleted Successfully");

			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(MovieSearchModel searchModel)
		{
			if (!string.IsNullOrWhiteSpace(searchModel.Title)) searchModel.Title = searchModel.Title.Trim();
			if (!string.IsNullOrWhiteSpace(Session["query"]?.ToString())) searchModel.Title = Session["query"].ToString();
			if (!string.IsNullOrWhiteSpace(Session["wish"]?.ToString())) searchModel.Title = Session["wish"].ToString();

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
		public virtual ActionResult CreateFromSearchResult(int releaseID, bool isTvShow)
		{
			var movie = isTvShow ? _tmdbService.SearchTVShowByID(releaseID) : _tmdbService.SearchMovieByID(releaseID);

			movie.UserID = User.Identity.GetUserId();

			ViewBag.Title = "Create";

			Session["movieResult"] = movie;

			return RedirectToAction(MVC.Movie.Create());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult AddToShowcase(int id)
		{
			var movie = _service.GetByID(id, User.Identity.GetUserId());
			movie.IsShowcased = true;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Title added to showcase", "Showcase");
			return RedirectToAction(MVC.Showcase.Index());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet]
		public virtual ActionResult RemoveFromShowcase(int id)
		{
			var movie = _service.GetByID(id, User.Identity.GetUserId());
			movie.IsShowcased = false;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Title removed from showcase", "Showcase");
			return RedirectToAction(MVC.Showcase.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult IncreaseCompletionCount(int id)
		{
			var movie = _service.GetByID(id, User.Identity.GetUserId());

			if (movie.UserID != User.Identity.GetUserId())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This movie cannot be edited by another user.", "Edit Failure");
				return RedirectToAction(MVC.Movie.Index());
			}

			movie.TimesCompleted += 1;
			if (movie.CompletionStatus != CompletionStatus.Completed) movie.CompletionStatus = CompletionStatus.Completed;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Movie was updated.", "Update");
			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult DecreaseCompletionCount(int id)
		{
			var movie = _service.GetByID(id, User.Identity.GetUserId());

			if (movie.UserID != User.Identity.GetUserId())
			{
				ShowStatusMessage(MessageTypeEnum.warning, "This movie cannot be edited by another user.", "Edit Failure");
				return RedirectToAction(MVC.Movie.Index());
			}

			if (movie.TimesCompleted > 0) movie.TimesCompleted -= 1;
			if (movie.TimesCompleted == 0) movie.CompletionStatus = CompletionStatus.NotStarted;
			movie.DateUpdated = DateTime.UtcNow;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.info, "Movie was updated.", "Update");
			return RedirectToAction(MVC.Movie.Index());
		}
	}
}