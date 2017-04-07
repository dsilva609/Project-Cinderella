using BusinessLogic.Enums;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class QueueController : ProjectCinderellaControllerBase
    {
        private readonly IUserContext _user;
        private readonly IAlbumService _albumService;
        private readonly IBookService _bookService;
        private readonly IGameService _gameService;
        private readonly IMovieService _movieService;

        public QueueController(IUserContext user, IAlbumService albumService, IBookService bookService, IGameService gameService,
            IMovieService movieService)
        {
            _user = user;
            _albumService = albumService;
            _bookService = bookService;
            _gameService = gameService;
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        public virtual ActionResult Index()
        {
            var model = new QueueViewModel
            {
                Albums = _albumService.GetAll(User.Identity.GetUserId())
                    .Where(x => x.IsQueued)
                    ?.OrderBy(y => y.QueueRank)
                    .Select(
                        z =>
                            new QueueItemViewModel
                            {
                                ID = z.ID,
                                Title = z.Title,
                                ImageUrl = z.ImageUrl,
                                QueueRank = z.QueueRank,
                                ItemType = ItemType.Album
                            })
                    .ToList(),
                Books = _bookService.GetAll(User.Identity.GetUserId())
                    .Where(x => x.IsQueued)
                    .OrderBy(y => y.QueueRank)
                    .Select(
                        z =>
                            new QueueItemViewModel
                            {
                                ID = z.ID,
                                Title = z.Title,
                                ImageUrl = z.ImageUrl,
                                QueueRank = z.QueueRank,
                                ItemType = ItemType.Book
                            })
                    .ToList(),
                Games = _gameService.GetAll(User.Identity.GetUserId())
                    .Where(x => x.IsQueued)
                    .OrderBy(y => y.QueueRank)
                    .Select(
                        z =>
                            new QueueItemViewModel
                            {
                                ID = z.ID,
                                Title = z.Title,
                                ImageUrl = z.ImageUrl,
                                QueueRank = z.QueueRank,
                                ItemType = ItemType.Game
                            })
                    .ToList(),
                Movies = _movieService.GetAll(User.Identity.GetUserId())
                    .Where(x => x.IsQueued)
                    .OrderBy(y => y.QueueRank)
                    .Select(
                        z =>
                            new QueueItemViewModel
                            {
                                ID = z.ID,
                                Title = z.Title,
                                ImageUrl = z.ImageUrl,
                                QueueRank = z.QueueRank,
                                ItemType = ItemType.Movie
                            })
                    .ToList()
            };
            return View(model);
        }
    }
}