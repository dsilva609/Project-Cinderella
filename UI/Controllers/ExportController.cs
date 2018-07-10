using BusinessLogic.Services.Interfaces;
using Newtonsoft.Json;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public partial class ExportController : ProjectCinderellaControllerBase
	{
		private readonly IAlbumService _albumService;

		public ExportController(IAlbumService albumService)
		{
			_albumService = albumService;
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
			var model = new AlbumExportModel
			{
				NumToExport = albums.Count,
				Json = JsonConvert.SerializeObject(albums, Formatting.Indented)
			};

			return View(MVC.Export.Views.AlbumExport, model);
		}
	}
}