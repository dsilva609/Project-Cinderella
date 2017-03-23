using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class QueueController : ProjectCinderellaControllerBase
	{
		[Authorize]
		[HttpGet]
		public virtual ActionResult Index()
		{
			return View();
		}
	}
}