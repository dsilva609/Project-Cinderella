using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectCinderella.Model.Enums;

namespace ProjectCinderella.UI.Models
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser, IUser<string>
	{
		public ItemType DefaultItemType { get; set; }
	}
}
