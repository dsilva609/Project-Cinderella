using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class MovieController : ProjectCinderellaControllerBase
	{
		private readonly IMovieService _service;
		private readonly ITMDBService _tmdbService;
		private const int NUM_MOVIES_TO_GET = 25;

		public MovieController(IMovieService service, ITMDBService tmdbService)
		{
			_service = service;
			_tmdbService = tmdbService;
		}

		[HttpGet]
		public virtual ActionResult Index(string query, int? pageNum)
		{
			var viewModel = new MovieViewModel
			{
				ViewTitle = "Index",
				Movies = _service.GetAll(User.Identity.GetUserId(), query, NUM_MOVIES_TO_GET, pageNum.GetValueOrDefault()),
				PageSize = NUM_MOVIES_TO_GET,
				TotalItems = _service.GetCount()
			};
			var pages = Math.Ceiling((double)viewModel.TotalItems / viewModel.PageSize);
			viewModel.PageCount = (int)pages;

			return View(viewModel);
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			ViewBag.Title = "Details";
			var model = _service.GetByID(id, User.Identity.GetUserId());

			return View(model);
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
				movie.DateAdded = DateTime.Now;
				this._service.Add(movie);
			}
			catch (Exception e)
			{
				ShowStatusMessage(MessageTypeEnum.error, e.Message, "Duplicate Movie");
				return View(movie);
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

			var existingMovies = _service.GetAll(User.Identity.GetUserId(), movie.Title);

			if (existingMovies.Count > 0 && existingMovies.Any(x => x.ID != movie.ID && x.Title == movie.Title && x.Type == movie.Type))
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A Game of Title: {movie.Title}, Media Type: {movie.Type} already exists.",
					"Duplicate Movie");
				return View(movie);
			}

			//TODO: make sure user id is the same so as not to change other users data
			movie.DateUpdated = DateTime.Now;
			_service.Edit(movie);

			ShowStatusMessage(MessageTypeEnum.success, $"Movie of Title {movie.Title}, Media Type: {movie.Type} updated.", "Update Successful");
			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Movie Deleted Successfully");

			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Search(MovieSearchModel searchModel)
		{
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
	}
}