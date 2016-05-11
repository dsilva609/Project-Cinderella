using BusinessLogic.DAL;
using BusinessLogic.Enums;
using BusinessLogic.Models;
using BusinessLogic.Repositories;
using BusinessLogic.Services;
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
		private readonly IUnitOfWork _uow;
		private readonly IMovieService _service;

		public MovieController()
		{
			_uow = new UnitOfWork<ProjectCinderellaContext>();
			_service = new MovieService(_uow);
		}

		[HttpGet]
		public virtual ActionResult Index(string query, int pageNum)
		{
			var viewModel = new MovieViewModel
			{
				ViewTitle = "Index",
				Movies = _service.GetAll(User.Identity.GetUserId())
				//, query, NUM_RECORDS_TO_GET, pageNum.GetValueOrDefault()),
				//PageSize = NUM_RECORDS_TO_GET,
				//TotalBooks = _service.GetCount()
			};
			//var pages = Math.Ceiling((double)viewModel.TotalRecords / viewModel.PageSize);
			//viewModel.PageCount = (int)pages;
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
			ViewBag.Title = "Create";
			var model = new Movie { UserID = User.Identity.GetUserId() };

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Create(Movie movie)
		{
			movie.UserID = User.Identity.GetUserId();
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

			return View(model);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Edit(Movie movie)
		{
			if (!ModelState.IsValid) return View(movie);
			//TODO: can probably just refactor this for it's actual call
			var existingMovie = _service.GetAll(User.Identity.GetUserId()).Where(x => x.ID != movie.ID && x.Title == movie.Title && x.Type == movie.Type).ToList();
			if (existingMovie.Count > 0)
			{
				ShowStatusMessage(MessageTypeEnum.error, $"A movie of Title: {movie.Title}, Media Type: {movie.Type} already exists.", "Duplicate Movie");
				return View(movie);
			}
			//--TODO: why is id needed?
			//TODO: make sure user id is the same so as not to change other users data
			movie.UserID = User.Identity.GetUserId();
			movie.DateUpdated = DateTime.Now;
			_service.Edit(movie.ID, movie);

			ShowStatusMessage(MessageTypeEnum.success, $"Movie of Title {movie.Title}, Media Type: {movie.Type} updated.", "Update Successful");
			return RedirectToAction(MVC.Movie.Index());
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Delete Successful");

			return RedirectToAction(MVC.Movie.Index());
		}
	}
}