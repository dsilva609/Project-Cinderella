//using System;
//using System.Security.Claims;
//using System.Security.Principal;

//namespace ProjectCinderellaCore.Common
//{
//	public static class IdentityExtensions
//	{
//		public static string GetDefaultItemType(this IIdentity identity)
//		{
//			var claim = ((ClaimsIdentity)identity).FindFirst("DefaultType");

//			return claim != null ? claim.Value : "Album";
//		}

//		public static string GetDefaultActionType(this IIdentity identity)
//		{
//			var claim = ((ClaimsIdentity)identity).FindFirst("DefaultAction");

//			return claim != null ? claim.Value : "Index";
//		}

//		public static int GetUserNum(this IIdentity identity)
//		{
//			var claim = ((ClaimsIdentity)identity).FindFirst("UserNum");

//			return claim != null ? Convert.ToInt32(claim.Value) : -1;
//		}

//		public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
//		{
//			var identity = currentPrincipal.Identity as ClaimsIdentity;
//			if (identity == null)
//				return;

//			var existingClaim = identity.FindFirst(key);
//			if (existingClaim != null)
//				identity.RemoveClaim(existingClaim);

//			identity.AddClaim(new Claim(key, value));
//			var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
//			authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity),
//				new AuthenticationProperties { IsPersistent = true });
//		}
//	}
//}