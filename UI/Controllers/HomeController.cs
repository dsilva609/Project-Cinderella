using BusinessLogic.Enums;
using BusinessLogic.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class HomeController : ProjectCinderellaControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IBookService _bookService;
        private readonly IMovieService _movieService;
        private readonly IGameService _gameService;
        private const int NUM_ALBUMS_TO_GET = 10;
        private const int NUM_BOOKS_TO_GET = 10;
        private const int NUM_MOVIES_TO_GET = 10;
        private const int NUM_GAMES_TO_GET = 10;

        public HomeController(IAlbumService albumService, IBookService bookService, IMovieService movieService, IGameService gameService)
        {
            _albumService = albumService;
            _bookService = bookService;
            _movieService = movieService;
            _gameService = gameService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
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

            var recordStoreDayTimer = new TimerModel { ID = "recordStoreDayTimer", Year = 2017, Month = 4, Day = 22 };
            var freeComicBookDayTimer = new TimerModel { ID = "freeComicBookDayTimer", Year = 2017, Month = 5, Day = 6 };

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
            Session["query"] = query.Trim();
            return RedirectToAction(act, type.ToString());
        }
    }
}