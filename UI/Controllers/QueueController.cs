using BusinessLogic.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public partial class QueueController : ProjectCinderellaControllerBase
	{
		private readonly IAlbumService _albumService;
		private readonly IBookService _bookService;
		private readonly IGameService _gameService;
		private readonly IMovieService _movieService;

		public QueueController(IAlbumService albumService, IBookService bookService, IGameService gameService, IMovieService movieService)
		{
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
				Albums = _albumService.GetAll(User.Identity.GetUserId()).Where(x => x.IsQueued)?.OrderBy(y => y.QueueRank)
					.Select(z => new QueueItemViewModel { ID = z.ID, Title = z.Title, ImageUrl = z.ImageUrl, QueueRank = z.QueueRank }).ToList(),
				Books = _bookService.GetAll(User.Identity.GetUserId()).Where(x => x.IsQueued).OrderBy(y => y.QueueRank)
					.Select(z => new QueueItemViewModel { ID = z.ID, Title = z.Title, ImageUrl = z.ImageUrl, QueueRank = z.QueueRank }).ToList(),
				Games = _gameService.GetAll(User.Identity.GetUserId()).Where(x => x.IsQueued).OrderBy(y => y.QueueRank)
					.Select(z => new QueueItemViewModel { ID = z.ID, Title = z.Title, ImageUrl = z.ImageUrl, QueueRank = z.QueueRank }).ToList(),
				Movies = _movieService.GetAll(User.Identity.GetUserId()).Where(x => x.IsQueued).OrderBy(y => y.QueueRank)
					.Select(z => new QueueItemViewModel { ID = z.ID, Title = z.Title, ImageUrl = z.ImageUrl, QueueRank = z.QueueRank }).ToList()
			};
			return View(model);
		}
	}
}