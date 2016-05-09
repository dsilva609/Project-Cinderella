using BusinessLogic.Enums;
using BusinessLogic.Models;
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
			var model = new Book();

			return View();
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Edit(int id)
		{
			ViewBag.Title = "Edit";

			return View();
		}

		[Authorize]
		[HttpGet]
		public virtual ActionResult Delete(int id)
		{
			//	_service.Delete(id, User.Identity.GetUserId());

			ShowStatusMessage(MessageTypeEnum.success, "", "Delete Successful");

			return RedirectToAction(MVC.Book.Index());
		}
	}
}