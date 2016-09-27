using System.Web.Mvc;

namespace UI.Controllers
{
	public partial class StatisticsController : ProjectCinderellaControllerBase
	{
		public virtual ActionResult Index()
		{
			return View();
		}
	}
}