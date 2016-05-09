using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class BookController : ProjectCinderellaControllerBase
	{
		public virtual ActionResult Index(string query, int pageNum = 1)
		{
			return View();
		}
	}
}