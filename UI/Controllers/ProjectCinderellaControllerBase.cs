using BusinessLogic.Enums;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
	public class ProjectCinderellaControllerBase : Controller
	{
		public ToastMessage ShowStatusMessage(MessageTypeEnum toastType, string message, string title)
		{
			var toastr = TempData["Toastr"] as Toastr;
			toastr = toastr ?? new Toastr();

			var toastMessage = toastr.AddToastMessage(title, message, toastType);
			TempData["Toastr"] = toastr;
			return toastMessage;
		}
	}
}