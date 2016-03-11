// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace UI.Controllers
{
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Login()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> VerifyCode()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.VerifyCode);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ConfirmEmail()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmEmail);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ResetPassword()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SendCode()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendCode);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult ExternalLogin()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginConfirmation);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Login = "Login";
            public readonly string VerifyCode = "VerifyCode";
            public readonly string Register = "Register";
            public readonly string ConfirmEmail = "ConfirmEmail";
            public readonly string ForgotPassword = "ForgotPassword";
            public readonly string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public readonly string ResetPassword = "ResetPassword";
            public readonly string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public readonly string SendCode = "SendCode";
            public readonly string ExternalLoginCallback = "ExternalLoginCallback";
            public readonly string ExternalLoginFailure = "ExternalLoginFailure";
            public readonly string ExternalLogin = "ExternalLogin";
            public readonly string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public readonly string LogOff = "LogOff";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Login = "Login";
            public const string VerifyCode = "VerifyCode";
            public const string Register = "Register";
            public const string ConfirmEmail = "ConfirmEmail";
            public const string ForgotPassword = "ForgotPassword";
            public const string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public const string ResetPassword = "ResetPassword";
            public const string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public const string SendCode = "SendCode";
            public const string ExternalLoginCallback = "ExternalLoginCallback";
            public const string ExternalLoginFailure = "ExternalLoginFailure";
            public const string ExternalLogin = "ExternalLogin";
            public const string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public const string LogOff = "LogOff";
        }


        static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Login
        {
            public readonly string returnUrl = "returnUrl";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_VerifyCode s_params_VerifyCode = new ActionParamsClass_VerifyCode();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_VerifyCode VerifyCodeParams { get { return s_params_VerifyCode; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_VerifyCode
        {
            public readonly string provider = "provider";
            public readonly string returnUrl = "returnUrl";
            public readonly string rememberMe = "rememberMe";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ConfirmEmail s_params_ConfirmEmail = new ActionParamsClass_ConfirmEmail();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ConfirmEmail ConfirmEmailParams { get { return s_params_ConfirmEmail; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ConfirmEmail
        {
            public readonly string userId = "userId";
            public readonly string code = "code";
        }
        static readonly ActionParamsClass_ResetPassword s_params_ResetPassword = new ActionParamsClass_ResetPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ResetPassword ResetPasswordParams { get { return s_params_ResetPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ResetPassword
        {
            public readonly string code = "code";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_SendCode s_params_SendCode = new ActionParamsClass_SendCode();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SendCode SendCodeParams { get { return s_params_SendCode; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SendCode
        {
            public readonly string returnUrl = "returnUrl";
            public readonly string rememberMe = "rememberMe";
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ExternalLoginCallback s_params_ExternalLoginCallback = new ActionParamsClass_ExternalLoginCallback();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLoginCallback ExternalLoginCallbackParams { get { return s_params_ExternalLoginCallback; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLoginCallback
        {
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ForgotPassword s_params_ForgotPassword = new ActionParamsClass_ForgotPassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ForgotPassword ForgotPasswordParams { get { return s_params_ForgotPassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ForgotPassword
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_ExternalLogin s_params_ExternalLogin = new ActionParamsClass_ExternalLogin();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLogin ExternalLoginParams { get { return s_params_ExternalLogin; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLogin
        {
            public readonly string provider = "provider";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_ExternalLoginConfirmation s_params_ExternalLoginConfirmation = new ActionParamsClass_ExternalLoginConfirmation();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ExternalLoginConfirmation ExternalLoginConfirmationParams { get { return s_params_ExternalLoginConfirmation; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ExternalLoginConfirmation
        {
            public readonly string model = "model";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _ChangePasswordPartial = "_ChangePasswordPartial";
                public readonly string _ExternalLoginsListPartial = "_ExternalLoginsListPartial";
                public readonly string _SetPasswordPartial = "_SetPasswordPartial";
                public readonly string ConfirmEmail = "ConfirmEmail";
                public readonly string ExternalLoginConfirmation = "ExternalLoginConfirmation";
                public readonly string ExternalLoginFailure = "ExternalLoginFailure";
                public readonly string ForgotPassword = "ForgotPassword";
                public readonly string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
                public readonly string Login = "Login";
                public readonly string Register = "Register";
                public readonly string ResetPassword = "ResetPassword";
                public readonly string ResetPasswordConfirmation = "ResetPasswordConfirmation";
                public readonly string SendCode = "SendCode";
                public readonly string VerifyCode = "VerifyCode";
            }
            public readonly string _ChangePasswordPartial = "~/Views/Account/_ChangePasswordPartial.cshtml";
            public readonly string _ExternalLoginsListPartial = "~/Views/Account/_ExternalLoginsListPartial.cshtml";
            public readonly string _SetPasswordPartial = "~/Views/Account/_SetPasswordPartial.cshtml";
            public readonly string ConfirmEmail = "~/Views/Account/ConfirmEmail.cshtml";
            public readonly string ExternalLoginConfirmation = "~/Views/Account/ExternalLoginConfirmation.cshtml";
            public readonly string ExternalLoginFailure = "~/Views/Account/ExternalLoginFailure.cshtml";
            public readonly string ForgotPassword = "~/Views/Account/ForgotPassword.cshtml";
            public readonly string ForgotPasswordConfirmation = "~/Views/Account/ForgotPasswordConfirmation.cshtml";
            public readonly string Login = "~/Views/Account/Login.cshtml";
            public readonly string Register = "~/Views/Account/Register.cshtml";
            public readonly string ResetPassword = "~/Views/Account/ResetPassword.cshtml";
            public readonly string ResetPasswordConfirmation = "~/Views/Account/ResetPasswordConfirmation.cshtml";
            public readonly string SendCode = "~/Views/Account/SendCode.cshtml";
            public readonly string VerifyCode = "~/Views/Account/VerifyCode.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : UI.Controllers.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult Login(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void VerifyCodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string provider, string returnUrl, bool rememberMe);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.VerifyCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "rememberMe", rememberMe);
            VerifyCodeOverride(callInfo, provider, returnUrl, rememberMe);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            RegisterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ConfirmEmailOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string userId, string code);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ConfirmEmail(string userId, string code)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ConfirmEmail);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userId", userId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "code", code);
            ConfirmEmailOverride(callInfo, userId, code);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ForgotPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ForgotPassword()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
            ForgotPasswordOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ForgotPasswordConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ForgotPasswordConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPasswordConfirmation);
            ForgotPasswordConfirmationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string code);

        [NonAction]
        public override System.Web.Mvc.ActionResult ResetPassword(string code)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "code", code);
            ResetPasswordOverride(callInfo, code);
            return callInfo;
        }

        [NonAction]
        partial void ResetPasswordConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ResetPasswordConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPasswordConfirmation);
            ResetPasswordConfirmationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void SendCodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl, bool rememberMe);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "rememberMe", rememberMe);
            SendCodeOverride(callInfo, returnUrl, rememberMe);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ExternalLoginCallbackOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginCallback);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginCallbackOverride(callInfo, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ExternalLoginFailureOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ExternalLoginFailure()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginFailure);
            ExternalLoginFailureOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.LoginViewModel model, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Login(UI.Models.LoginViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LoginOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void VerifyCodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.VerifyCodeViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> VerifyCode(UI.Models.VerifyCodeViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.VerifyCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            VerifyCodeOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.RegisterViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Register(UI.Models.RegisterViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RegisterOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ForgotPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.ForgotPasswordViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ForgotPassword(UI.Models.ForgotPasswordViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ForgotPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ForgotPasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ResetPasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.ResetPasswordViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ResetPassword(UI.Models.ResetPasswordViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResetPassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ResetPasswordOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ExternalLoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string provider, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult ExternalLogin(string provider, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLogin);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "provider", provider);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginOverride(callInfo, provider, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void SendCodeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.SendCodeViewModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SendCode(UI.Models.SendCodeViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SendCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SendCodeOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ExternalLoginConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UI.Models.ExternalLoginConfirmationViewModel model, string returnUrl);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ExternalLoginConfirmation(UI.Models.ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ExternalLoginConfirmation);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            ExternalLoginConfirmationOverride(callInfo, model, returnUrl);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
