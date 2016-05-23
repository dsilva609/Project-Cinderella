using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class HomeController : Controller
	{
		[HttpGet]
		public virtual ActionResult Index()
		{
			return View();
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
		public virtual ActionResult Test()
		{
			return View();
		}
	}
}