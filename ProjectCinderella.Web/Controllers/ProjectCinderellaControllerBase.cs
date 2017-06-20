using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectCinderella.Model.UI;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Common;
using ProjectCinderella.Web.Areas.IdentityService.Models;
using ProjectCinderella.Web.Common;

namespace ProjectCinderella.Web.Controllers
{
	//--TODO: can this be set to protected?
	public class ProjectCinderellaControllerBase : Controller
	{
		//private ApplicationUser _user;
		//private readonly ApplicationUserManager _userManager;

		//public ProjectCinderellaControllerBase(ApplicationUserManager userManager)
		//{
		//	_userManager = userManager;
		//}

		//public ApplicationUser GetUser() => _userManager.FindByNameAsync(User.Identity.Name).Result;

		public ToastMessage ShowStatusMessage(MessageTypeEnum toastType, string message, string title)
		{
			var toastrVal = TempData["Toastr"]?.ToString();
			var toastr = string.IsNullOrWhiteSpace(toastrVal) ? new Toastr(): JsonConvert.DeserializeObject<Toastr>(toastrVal);

			var toastMessage = toastr.AddToastMessage(title, message, toastType);
			TempData["Toastr"] = JsonConvert.SerializeObject(toastr);
			return toastMessage;
		}

		public void SetTimeStamps(BaseItem model)
		{
			if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.InProgress) model.DateStarted = DateTime.UtcNow;
			else if (model.CompletionStatus == ProjectCinderella.Model.Enums.CompletionStatus.Completed) model.DateCompleted = DateTime.UtcNow;
		}
	}
}