using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ProjectCinderella.UI.Models
{
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(UserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor,
			IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators,
			IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer,
			IdentityErrorDescriber errors, IServiceProvider serviceProvider,
			ILogger<UserManager<ApplicationUser>> logger)
			: base(
				store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
				serviceProvider,logger)
		{
		}
	}
}
