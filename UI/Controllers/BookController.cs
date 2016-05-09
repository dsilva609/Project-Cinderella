using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class BookController : ProjectCinderellaControllerBase
	{
		public virtual ActionResult Index()
		{
			return View();
		}
	}
}