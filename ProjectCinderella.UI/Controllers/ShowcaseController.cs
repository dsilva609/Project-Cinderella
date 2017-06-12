using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.Model.UI;
using System.Linq;

namespace ProjectCinderella.UI.Controllers
{
	public class ShowcaseController : Controller
	{
		private readonly IUserContext _user;
		private readonly IAlbumService _albumService;
		private readonly IBookService _bookService;
		private readonly IGameService _gameService;
		private readonly IMovieService _movieService;
		private readonly IPopService _popService;

		public ShowcaseController(IUserContext user, IAlbumService albumService, IBookService bookService, IGameService gameService,
			IMovieService movieService,
			IPopService popService)
		{
			_user = user;
			_albumService = albumService;
			_bookService = bookService;
			_gameService = gameService;
			_movieService = movieService;
			_popService = popService;
		}

		[HttpGet]
		public virtual ActionResult Index(int id)
		{
			var model = new ShowcaseViewModel
			{
				ViewTitle = "Showcase",
				Albums = _albumService.GetAll().Where(x => x.IsShowcased && x.UserNum == id).ToList(),
				Books = _bookService.GetAll().Where(x => x.IsShowcased && x.UserNum == id).ToList(),
				Games = _gameService.GetAll().Where(x => x.IsShowcased && x.UserNum == id).ToList(),
				Movies = _movieService.GetAll().Where(x => x.IsShowcased && x.UserNum == id).ToList(),
				Pops = _popService.GetAll().Where(x => x.IsShowcased && x.UserNum == id).ToList()
			};

			return View(model);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public virtual ActionResult Add()
		{
			ViewBag.Title = "Add";

			return View();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public virtual ActionResult SearchItems(string query, ItemType type)
		{
			HttpContext.Session.SetString($"{type.ToString().ToLower()}-query", query.Trim());
			return RedirectToAction("Index","Showcase", (string) type.ToString());
		}
	}
}