using System.Web;
using BusinessLogic.Enums;
using BusinessLogic.Models.Interfaces;
using Microsoft.AspNet.Identity;

namespace BusinessLogic.Models
{
    public class UserContext : IUserContext
    {
        public bool IsAuthenticated()
        {
            throw new System.NotImplementedException();
        }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public string GetUserID() => HttpContext.Current.User.Identity.GetUserId();

        public int GetUserNum()
        {
            throw new System.NotImplementedException();
        }

        public ItemType GetDefaultType()
        {
            throw new System.NotImplementedException();
        }

        //TODO: move enum to business logic
        //public ActionType GetDefaultAction()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}