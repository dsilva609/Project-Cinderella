using BusinessLogic.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Common;
using UI.Enums;
using UI.Models;

namespace UI.Controllers
{
	[Authorize]
	public partial class ManageController : ProjectCinderellaControllerBase
	{
		private ApplicationUserManager _userManager;

		public ApplicationUserManager UserManager
		{
			get { return this._userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
			private set { this._userManager = value; }
		}

		#region HttpGet

		[HttpGet]
		public virtual async Task<ActionResult> Index(ManageMessageId? message)
		{
			var model = new IndexViewModel
			{
				HasPassword = HasPassword(),
				TwoFactor = await UserManager.GetTwoFactorEnabledAsync(User.Identity.GetUserId()),
				Logins = await UserManager.GetLoginsAsync(User.Identity.GetUserId()),
				BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(User.Identity.GetUserId()),
				Type = (ItemType)Enum.Parse(typeof(ItemType), User.Identity.GetDefaultItemType()),
				Action = ActionType.GetByValue(User.Identity.GetDefaultActionType())
			};
			return View(model);
		}

		//[HttpGet]
		//public virtual ActionResult RemoveLogin()
		//{
		//	var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
		//	ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
		//	return View(linkedAccounts);
		//}

		[HttpGet]
		public virtual ActionResult ChangePassword()
		{
			return View();
		}

		[HttpGet]
		public virtual ActionResult SetPassword()
		{
			return View();
		}

		[HttpGet]
		public virtual async Task<ActionResult> ManageLogins(ManageMessageId? message)
		{
			ViewBag.StatusMessage =
				message == ManageMessageId.RemoveLoginSuccess
					? "The external login was removed."
					: message == ManageMessageId.Error
						? "An error has occurred."
						: "";
			var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
			if (user == null)
			{
				return View("Error");
			}
			var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
			var otherLogins =
				AuthenticationManager.GetExternalAuthenticationTypes()
					.Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider))
					.ToList();
			ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
			return View(new ManageLoginsViewModel
			{
				CurrentLogins = userLogins,
				OtherLogins = otherLogins
			});
		}

		[HttpGet]
		public virtual async Task<ActionResult> LinkLoginCallback()
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
			if (loginInfo == null)
			{
				return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
			}
			var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
			return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
		}

		#endregion HttpGet

		#region HttpPost

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
		{
			ManageMessageId? message;
			var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
			if (result.Succeeded)
			{
				var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
				if (user != null)
				{
					await SignInAsync(user, isPersistent: false);
				}
				message = ManageMessageId.RemoveLoginSuccess;
			}
			else
			{
				message = ManageMessageId.Error;
			}
			return RedirectToAction("ManageLogins", new { Message = message });
		}

		[HttpPost]
		public virtual async Task<ActionResult> EnableTwoFactorAuthentication()
		{
			await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), true);
			var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
			if (user != null)
			{
				await SignInAsync(user, isPersistent: false);
			}
			return RedirectToAction("Index", "Manage");
		}

		[HttpPost]
		public virtual async Task<ActionResult> DisableTwoFactorAuthentication()
		{
			await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
			var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
			if (user != null)
			{
				await SignInAsync(user, isPersistent: false);
			}
			return RedirectToAction("Index", "Manage");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
			if (result.Succeeded)
			{
				var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
				if (user != null)
				{
					await SignInAsync(user, isPersistent: false);
				}
				return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
			}
			AddErrors(result);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> SetPassword(SetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
				if (result.Succeeded)
				{
					var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
					if (user != null)
					{
						await SignInAsync(user, isPersistent: false);
					}
					return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
				}
				AddErrors(result);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult LinkLogin(string provider)
		{
			// Request a redirect to the external login provider to link a login for the current user
			return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult Update(IndexViewModel model)
		{
			var store = new UserStore<ApplicationUser>(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
			var manager = new UserManager<ApplicationUser>(store);
			var user = manager.FindById(User.Identity.GetUserId());
			if (model.Type == ItemType.Pop && model.ActionValue == ActionType.SearchOnline.Value)
			{
				model.ActionValue = "Index";
				ShowStatusMessage(MessageTypeEnum.info, "Search online for Pops is currently not available. Defaulting to View Collection.",
					"Default Action Update");
			}
			user.DefaultType = model.Type;
			user.DefaultAction = ActionType.GetByValue(model.ActionValue);

			User.AddUpdateClaim("DefaultType", model.Type.ToString());
			User.AddUpdateClaim("DefaultAction", user.DefaultAction.Value);

			manager.Update(user);
			store.Context.SaveChanges();
			ShowStatusMessage(MessageTypeEnum.success, "Successfully Updated User", "Success");

			return RedirectToAction(MVC.Manage.Index());
		}

		#endregion HttpPost

		#region Helpers

		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager
		{
			get { return HttpContext.GetOwinContext().Authentication; }
		}

		private async Task SignInAsync(ApplicationUser user, bool isPersistent)
		{
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
			AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent },
				await user.GenerateUserIdentityAsync(UserManager));
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		private bool HasPassword()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			if (user != null)
			{
				return user.PasswordHash != null;
			}
			return false;
		}

		public enum ManageMessageId
		{
			ChangePasswordSuccess,
			SetTwoFactorSuccess,
			SetPasswordSuccess,
			RemoveLoginSuccess,
			Error
		}

		#endregion Helpers
	}
}