using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCinderellaCore.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ElmahController : Controller
	{
		//TODO: comeback to this
		public virtual ActionResult Index(string type)
		{
			throw new NotImplementedException();
			//return new Elmah.ElmahResult(type);
		}
	}
}