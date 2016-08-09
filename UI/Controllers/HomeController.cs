using BusinessLogic.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IBookService _bookService;
        private const int NUMALBUMSTOGET = 10;
        private const int NUMBOOKSTOGET = 10;

        public HomeController(IAlbumService albumService, IBookService bookService)
        {
            _albumService = albumService;
            _bookService = bookService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            //TODO - update service to take latest of x amount
            var albums = _albumService.GetAll().OrderByDescending(x => x.DateAdded).Take(NUMALBUMSTOGET).ToList();
            var books = _bookService.GetAll(string.Empty, string.Empty, NUMBOOKSTOGET);
            var model = new HomeViewModel
            {
                Albums = albums,
                Books = books
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
            ViewBag.Message = "Find me on social media.";

            return View();
        }
    }
}