using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectCinderella.Web.Areas.IdentityService.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IUser<string>
    {
		public int UserNum { get; set; }
    }
}
