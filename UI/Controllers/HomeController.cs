using System;
using System.Data.Entity.Validation;
using BusinessLogic.Enums;
using BusinessLogic.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Models;
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
		public virtual ActionResult UpdateAlbums()
		{
			var albums = _albumService.GetAll().Where(x => string.IsNullOrWhiteSpace(x.Style)).ToList();

			foreach (var album in albums)
			{
				try
				{
					//if (!string.IsNullOrWhiteSpace(album.Genre) && !string.IsNullOrWhiteSpace(album.Style)) continue;

					var origGenre = album.Genre;
					if (string.IsNullOrWhiteSpace(origGenre)) continue;
					else
					{
						var firstDashIndex = origGenre.IndexOf('-');
						var firstCommaIndex = origGenre.IndexOf(',');
						var genre = string.Empty;
						var style = string.Empty;

						if (firstDashIndex < firstCommaIndex && firstCommaIndex != -1 && firstDashIndex != -1)
						{
							genre = origGenre.Substring(0, firstDashIndex);
							style = origGenre.Substring(firstDashIndex + 1);
						}
						else if (firstCommaIndex == -1 && firstDashIndex == -1)
						{
							continue;
						}
						else if (firstCommaIndex < firstDashIndex && firstCommaIndex != -1)
						{
							genre = origGenre.Substring(0, firstCommaIndex);
							style = origGenre.Substring(firstCommaIndex + 1);
						}
						else if (firstDashIndex > 0 && firstCommaIndex == -1)
						{
							genre = origGenre.Substring(0, firstDashIndex);
							style = origGenre.Substring(firstDashIndex + 1);
						}
						else if (firstCommaIndex > 0 && firstDashIndex == -1)
						{
							genre = origGenre.Substring(0, firstCommaIndex);
							style = origGenre.Substring(firstCommaIndex + 1);
						}
						album.Genre = genre.Trim();
						style = style.TrimStart(',');
						album.Style = style.Trim();
						album.DateUpdated = DateTime.UtcNow;
						_albumService.Edit(album);
					}
				}
				catch (DbEntityValidationException e)
				{
					foreach (var eve in e.EntityValidationErrors)
					{
						Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
							eve.Entry.Entity.GetType().Name, eve.Entry.State);
						foreach (var ve in eve.ValidationErrors)
						{
							Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
								ve.PropertyName, ve.ErrorMessage);
						}
					}
				}
				catch (Exception e)
				{
					throw new Exception($"Error occurred for {album.ID}, + {e.Message}");
				}
			}

			ShowStatusMessage(MessageTypeEnum.info, "Updated albums", "Update");
			return RedirectToAction(MVC.Home.Index());
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

			var model = new HomeViewModel
			{
				Albums = albums,
				UpdatedAlbums = updatedAlbums,
				Books = books,
				UpdatedBooks = updatedBooks,
				Movies = movies,
				UpdatedMovies = updatedMovies,
				Games = games,
				UpdatedGames = updatedGames
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

		[HttpGet]
		public virtual ActionResult Search(string query, ItemType type, string act)
		{
			Session["query"] = query.Trim();
			return RedirectToAction(act, type.ToString());
		}
	}
}