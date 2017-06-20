using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjectCinderella.Web.Areas.IdentityService.Models;

namespace ProjectCinderella.Web.Common
{
	//public class ClaimsTransformer : IClaimsTransformer
	//{
	//	public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
	//	{
	//		((ClaimsIdentity)principal.Identity).AddClaim(new Claim("ProjectReader", "true"));
	//		return Task.FromResult(principal);
	//	}
	//}

	public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AppClaimsPrincipalFactory(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			//SignInManager<ApplicationUser> signInManager,
			IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
		{
			_userManager = userManager;
			//_signInManager = signInManager;
		}

		public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
			var principal = await base.CreateAsync(user);

			var claim = new Claim("UserNum", user.UserNum.ToString());
			((ClaimsIdentity) principal.Identity).AddClaims(new[] {claim});
			await _userManager.AddClaimAsync(user, claim);

			//await _signInManager.RefreshSignInAsync(user);
			return principal;
		}
	}
}


