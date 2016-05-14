using BusinessLogic.Services.Interfaces;
using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class GameController : Controller
	{
		private readonly IGameService _service;

		public GameController(IGameService service)
		{
			_service = service;
		}

		public virtual ActionResult Index()
		{
			return View();
		}
	}
}