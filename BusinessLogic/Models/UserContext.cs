using BusinessLogic.Enums;
using BusinessLogic.Models.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Security.Claims;
using System.Web;

namespace BusinessLogic.Models
{
    public class UserContext : IUserContext
    {
        public bool IsAuthenticated() => HttpContext.Current.User.Identity.IsAuthenticated;

        public bool IsInRole(string role) => HttpContext.Current.User.IsInRole(role);

        public string GetUserID() => HttpContext.Current.User.Identity.GetUserId();

        public int GetUserNum() => Convert.ToInt32(((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirstValue("UserNum"));

        public ItemType GetDefaultType() => (ItemType)Convert.ToInt32(
            ((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirstValue("DefaultType"));

        //TODO: move enum to business logic
        //public ActionType GetDefaultAction()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}