using BusinessLogic.Enums;
using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class ExportController : ProjectCinderellaControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly IBookService _bookService;
        private readonly IGameService _gameService;
        private readonly IMovieService _movieService;
        private readonly IPopService _popService;

        public ExportController(IAlbumService albumService, IBookService bookService, IGameService gameService, IMovieService movieService, IPopService popService)
        {
            _albumService = albumService;
            _bookService = bookService;
            _gameService = gameService;
            _movieService = movieService;
            _popService = popService;
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult GetAlbumsForExport()
        {
            var albums = _albumService.GetAll();
            var model = new ExportModel
            {
                NumToExport = albums.Count,
                Json = JsonConvert.SerializeObject(albums, Formatting.Indented)
            };

            return View(MVC.Export.Views.Export, model);
        }

        [HttpGet]
        public virtual ActionResult GetBooksForExport()
        {
            var books = _bookService.GetAll();
            var model = new ExportModel
            {
                NumToExport = books.Count,
                Json = JsonConvert.SerializeObject(books, Formatting.Indented)
            };

            return View(MVC.Export.Views.Export, model);
        }

        [HttpGet]
        public virtual ActionResult GetGamesForExport()
        {
            var games = _gameService.GetAll();
            var model = new ExportModel
            {
                NumToExport = games.Count,
                Json = JsonConvert.SerializeObject(games, Formatting.Indented)
            };

            return View(MVC.Export.Views.Export, model);
        }

        [HttpGet]
        public virtual ActionResult GetMoviesForExport()
        {
            var movies = _movieService.GetAll();
            var model = new ExportModel
            {
                NumToExport = movies.Count,
                Json = JsonConvert.SerializeObject(movies, Formatting.Indented)
            };

            return View(MVC.Export.Views.Export, model);
        }

        [HttpGet]
        public virtual ActionResult GetPopsForExport()
        {
            var pops = _popService.GetAll();
            var model = new ExportModel
            {
                NumToExport = pops.Count,
                Json = JsonConvert.SerializeObject(pops, Formatting.Indented)
            };

            return View(MVC.Export.Views.Export, model);
        }

        [HttpGet]
        public virtual ActionResult ExportAlbums()
        {
            var albums = _albumService.GetAll().Where(x => !string.IsNullOrWhiteSpace(x.Title)).ToList();
            var client = new RestClient("https://cinderellacore.azurewebsites.net");
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("Authorization", "test");

            var request = new RestRequest("api/Import/ImportAlbums", Method.POST);
            var importRequest = new AlbumImportRequest
            {
                UserID = "3def12c9-2b38-4685-8f70-f37ac2be076d",
                Albums = albums
            };
            request.AddBody(importRequest);

            var result = client.Execute(request);

            if (result.IsSuccessful) ShowStatusMessage(MessageTypeEnum.info, result.Content, "Import Successful");
            else ShowStatusMessage(MessageTypeEnum.error, result.Content, "Import failed");

            return RedirectToAction(MVC.Export.Index());
        }

        [HttpGet]
        public virtual ActionResult ExportBooks()
        {
            var books = _bookService.GetAll();
            var client = new RestClient("https://cinderellacore.azurewebsites.net");
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("Authorization", "test");

            var request = new RestRequest("api/Import/ImportBooks", Method.POST);
            var importRequest = new BookImportRequest
            {
                UserID = "3def12c9-2b38-4685-8f70-f37ac2be076d",
                Books = books
            };
            request.AddBody(importRequest);

            var result = client.Execute(request);

            if (result.IsSuccessful) ShowStatusMessage(MessageTypeEnum.info, result.Content, "Import Successful");
            else ShowStatusMessage(MessageTypeEnum.error, result.Content, "Import failed");

            return RedirectToAction(MVC.Export.Index());
        }

        [HttpGet]
        public virtual ActionResult ExportGames()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual ActionResult ExportMovies()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual ActionResult ExportPops()
        {
            throw new NotImplementedException();
        }
    }
}