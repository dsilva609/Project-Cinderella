using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderellaCore.Areas.IdentityService.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
	    public ItemType DefaultItemType  { get; set; }
    }
}
