using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace UI.Common
{
    public static class IdentityExtensions
    {
        public static string GetDefaultItemType(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DefaultType");
            // Test for null to avoid issues during local testing
            return claim != null ? claim.Value : "Album";
        }

        public static string GetDefaultActionType(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DefaultAction");
            // Test for null to avoid issues during local testing
            return claim != null ? claim.Value : "Index";
        }

        public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity),
                new AuthenticationProperties { IsPersistent = true });
        }
    }
}