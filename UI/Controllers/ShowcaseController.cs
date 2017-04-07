using BusinessLogic.Enums;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class ShowcaseController : Controller
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
            Session["query"] = query.Trim();
            return RedirectToAction("Index", type.ToString());
        }
    }
}