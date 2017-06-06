using System;
using System.Net.Http;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using ProjectCinderella.Model.Enums;
using ProjectCinderella.Model.Interfaces;

namespace ProjectCinderella.Model.Common
{
	public class UserContext : IUserContext
	{
		private readonly IHttpContextAccessor _contextAccessor;
		private HttpContext _context => _contextAccessor.HttpContext;

		public UserContext(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}
		public bool IsAuthenticated() => _context.User.Identity.IsAuthenticated;

		public bool IsInRole(string role) => _context.User.IsInRole(role);

		public string GetUserID() => _context.User.Identity.GetUserId();

		public int GetUserNum() => Convert.ToInt32(((ClaimsIdentity)_context.User.Identity).FindFirstValue("UserNum"));

		public ItemType GetDefaultType() => (ItemType)Convert.ToInt32(
			((ClaimsIdentity)_context.User.Identity).FindFirstValue("DefaultType"));

		//TODO: move enum to business logic
		//public ActionType GetDefaultAction()
		//{
		//    throw new System.NotImplementedException();
		//}
	}
}