using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class MovieController : ProjectCinderellaControllerBase
	{
		[HttpGet]
		public virtual ActionResult Index(string query, int pageNum)
		{
			return View();
		}

		[HttpGet]
		public virtual ActionResult Details(int id)
		{
			ViewBag.Title = "Details";

			return View();
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Create()
		{
			ViewBag.Title = "Create";
			return View();
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			ViewBag.Title = "Edit";

			return View();
		}
	}
}