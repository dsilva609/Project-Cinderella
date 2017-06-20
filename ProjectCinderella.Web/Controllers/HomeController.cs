using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProjectCinderella.BusinessLogic.Services.Interfaces;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Interfaces;
using ProjectCinderella.Model.UI;
using System.Linq;
using ProjectCinderella.Web.Areas.IdentityService.Models;
using ProjectCinderella.Web.Common;
using ProjectCinderella.Web.Identity.Models;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Web.Controllers
{
	public class HomeController : ProjectCinderellaControllerBase
	{
		//private readonly IUserContext _user;
		//private readonly ApplicationUser _user;

		private readonly ApplicationUserManager _userManager;
		private readonly IUserContext _userContext;
		private readonly IAlbumService _albumService;
		private readonly IBookService _bookService;
		private readonly IMovieService _movieService;
		private readonly IGameService _gameService;
		private readonly IPopService _popService;
		private readonly ServiceSettings _settings;
		private const int NUM_ALBUMS_TO_GET = 10;
		private const int NUM_BOOKS_TO_GET = 10;
		private const int NUM_MOVIES_TO_GET = 10;
		private const int NUM_GAMES_TO_GET = 10;
		private const int NUM_POPS_TO_GET = 10;

		public HomeController(ApplicationUserManager userManager,  IAlbumService albumService, IBookService bookService, IMovieService movieService,
			IGameService gameService, IPopService popService, ServiceSettings settings)//: base(userManager)
		{
			//_userContext = userContext;
	//	_user = user;
			_userManager = userManager;
			
			
			_albumService = albumService;
		_bookService = bookService;
		_movieService = movieService;
			_gameService = gameService;
			_popService = popService;
			_settings = settings;
			
		}
		public ApplicationUser GetUser() => _userManager.FindByNameAsync(User.Identity.Name).Result;

		[HttpGet]
		public virtual ActionResult Index()
		{

			var num = GetUser().UserNum;

			//TODO: needs refactor to take asc/desc
			var albums = _albumService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateAdded).Take(NUM_ALBUMS_TO_GET).ToList();
			var updatedAlbums =
				_albumService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateUpdated).Take(NUM_ALBUMS_TO_GET).ToList();

			var books = _bookService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateAdded).Take(NUM_BOOKS_TO_GET).ToList();
			var updatedBooks = _bookService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateUpdated).Take(NUM_BOOKS_TO_GET).ToList();

			var movies = _movieService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateAdded).Take(NUM_MOVIES_TO_GET).ToList();
			var updatedMovies =
				_movieService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateUpdated).Take(NUM_MOVIES_TO_GET).ToList();

			var games = _gameService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateAdded).Take(NUM_GAMES_TO_GET).ToList();
			var updatedGames = _gameService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateUpdated).Take(NUM_GAMES_TO_GET).ToList();

			var pops = _popService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateAdded).Take(NUM_POPS_TO_GET).ToList();
			var updatedPops = _popService.GetAll(string.Empty, string.Empty).OrderByDescending(x => x.DateUpdated).Take(NUM_POPS_TO_GET).ToList();

			var recordStoreDate =_settings.RecordStoreDayDate;
			var recordStoreDayTimer = new TimerModel { ID = "recordStoreDayTimer", Year = recordStoreDate.Year, Month = recordStoreDate.Month, Day = recordStoreDate.Day };

			var freeComicBookDayDate = _settings.FreeComicBookDayDate;
			var freeComicBookDayTimer = new TimerModel { ID = "freeComicBookDayTimer", Year = freeComicBookDayDate.Year, Month = freeComicBookDayDate.Month, Day = freeComicBookDayDate.Day };

			var model = new HomeViewModel
			{
				Albums = albums,
				UpdatedAlbums = updatedAlbums,
				Books = books,
				UpdatedBooks = updatedBooks,
				Movies = movies,
				UpdatedMovies = updatedMovies,
				Games = games,
				UpdatedGames = updatedGames,
				Pops = pops,
				UpdatedPops = updatedPops,
				RecordStoreDayTimer = recordStoreDayTimer,
				FreeComicBookDayTimer = freeComicBookDayTimer
			};

			return View(model);
		}

		[HttpGet]
		public virtual ActionResult About()
		{
			ViewBag.Message = "Project Cinderella.";

			return View();
		}

		[HttpGet]
		public virtual ActionResult Contact()
		{
			ViewBag.Message = "Contact and Heavy Metal Friday Updates";

			return View();
		}

		[HttpGet]
		public virtual ActionResult Search(string query, ItemType type, string act)
		{
			if (type == ItemType.Pop && act == "Search") act = "Index";

			HttpContext.Session.SetString($"{type.ToString().ToLower()}-query", query.Trim());
			return RedirectToAction(act, type.ToString() as string);
		}
	}
}