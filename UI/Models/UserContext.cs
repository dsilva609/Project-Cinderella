using BusinessLogic.Enums;
using Microsoft.AspNet.Identity;
using System.Web;
using UI.Enums;
using UI.Models.Interfaces;

namespace UI.Models
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

        public ActionType GetDefaultAction()
        {
            throw new System.NotImplementedException();
        }
    }
}