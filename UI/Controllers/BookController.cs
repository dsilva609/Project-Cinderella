using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class BookController : ProjectCinderellaControllerBase
	{
		[HttpGet]
		public virtual ActionResult Index(string query, int pageNum = 1)
		{
			return View();
		}

		[HttpGet]
		public virtual ActionResult Create()
		{
			return View();
		}
	}
}