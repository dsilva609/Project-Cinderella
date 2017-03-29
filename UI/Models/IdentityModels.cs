using BusinessLogic.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Enums;

namespace UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ItemType DefaultType { get; set; }
        public ActionType DefaultAction { get; set; }
        public int UserNum { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("DefaultType", DefaultType.ToString()));
            userIdentity.AddClaim(new Claim("DefaultAction", string.IsNullOrWhiteSpace(DefaultAction.Value) ? string.Empty : DefaultAction.Value));
            //var latestUser = new ApplicationDbContext().Users.OrderByDescending(x => x.UserNum).FirstOrDefault();
            userIdentity.AddClaim(new Claim("UserNum", UserNum.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ProjectCinderella", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}