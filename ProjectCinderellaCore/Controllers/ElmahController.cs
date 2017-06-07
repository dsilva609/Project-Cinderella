using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCinderellaCore.Controllers
{
	[Authorize(Roles = "Admin")]
	public partial class ElmahController : Controller
	{
		public virtual ActionResult Index(string type)
		{
			return new ElmahResult(type);
		}
	}
}