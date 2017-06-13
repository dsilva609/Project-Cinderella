using System;
using Microsoft.AspNetCore.Mvc;
using ProjectCinderella.Model.UI;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Common;

namespace ProjectCinderella.Web.Controllers
{
	//--TODO: can this be set to protected?
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

		public void SetTimeStamps(BaseItem model)
		{
			if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.InProgress) model.DateStarted = DateTime.UtcNow;
			else if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed) model.DateCompleted = DateTime.UtcNow;
		}
	}
}