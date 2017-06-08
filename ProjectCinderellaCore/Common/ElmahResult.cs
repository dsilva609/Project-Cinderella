//using System;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ProjectCinderellaCore.Common
//{
//	internal class ElmahResult : ActionResult
//	{
//		private string _resouceType;

//		public ElmahResult(string resouceType)
//		{
//			_resouceType = resouceType;
//		}

//		public override void ExecuteResult(ControllerContext context)
//		{
//			var factory = new Elmah.ErrorLogPageFactory();

//			if (!string.IsNullOrEmpty(_resouceType))
//			{
//				var pathInfo = "." + _resouceType;
//				HttpContext.Current.RewritePath(PathForStylesheet(), pathInfo, HttpContext.Current.Request.QueryString.ToString());
//			}

//			var httpHandler = factory.GetHandler(HttpContext.Current, null, null, null);
//			httpHandler.ProcessRequest(HttpContext.Current);
//		}

//		private string PathForStylesheet()
//		{
//			return _resouceType != "stylesheet" ? HttpContext.Path.Replace(String.Format("/{0}", _resouceType), string.Empty) : HttpContext.Path;
//		}
//	}
//}