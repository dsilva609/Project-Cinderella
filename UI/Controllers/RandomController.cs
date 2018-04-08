using System.Web.Mvc;
using BusinessLogic.Models.Interfaces;
using BusinessLogic.Services.Interfaces;

namespace UI.Controllers
{
	public partial class RandomController : ProjectCinderellaControllerBase
	{
		private readonly IUserContext _user;
		private readonly IAlbumService _albumService;

		public RandomController(IUserContext user, IAlbumService albumService)
		{
			_user = user;
			_albumService = albumService;
		}

		[HttpGet]
		public virtual ActionResult RandomizeAlbums(int count)
		{
			var albums = _albumService.GetRandomAlbums(_user.GetUserID(), count);

			return View(MVC.Random.Views.RandomAlbums, albums);
		}
	}
}