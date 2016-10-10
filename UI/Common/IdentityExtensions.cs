using System.Security.Claims;
using System.Security.Principal;

namespace UI.Common
{
    public static class IdentityExtensions
    {
        public static string GetItemType(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Type");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}