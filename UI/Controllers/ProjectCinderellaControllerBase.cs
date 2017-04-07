using BusinessLogic.Enums;
using BusinessLogic.Models;
using System;
using System.Web.Mvc;
using UI.Models;
using CompletionStatus = BusinessLogic.Enums.CompletionStatus;

namespace UI.Controllers
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
            if (model.CompletionStatus == CompletionStatus.InProgress) model.DateStarted = DateTime.UtcNow;
            else if (model.CompletionStatus == CompletionStatus.Completed) model.DateCompleted = DateTime.UtcNow;
        }
    }
}