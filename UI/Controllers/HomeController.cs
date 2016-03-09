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
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[HttpGet]
		public virtual ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}