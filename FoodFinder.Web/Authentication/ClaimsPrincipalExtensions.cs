using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace FoodFinder.Web.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetVenueId(this IPrincipal principal)
        {
            Guid venueId;
            Guid.TryParse(GetClaimValueOrDefault(principal, "venueid"), out venueId);

            return venueId;
        }

        public static string GetName(this IPrincipal principal)
        {
            return GetClaimValueOrDefault(principal, "name");
        }

        public static string GetNickName(this IPrincipal principal)
        {
            return GetClaimValueOrDefault(principal, "nickname");
        }

        public static string GetUserId(this IPrincipal principal)
        {
            return GetClaimValueOrDefault(principal, "user_id");
        }


        private static string GetClaimValueOrDefault(IPrincipal principal, string claimType)
        {
            if (claimType == null)
                throw new ArgumentNullException(nameof(claimType));

            var claimsPrincipal = principal as ClaimsPrincipal;

            return claimsPrincipal?.Claims
                .Where(x => claimType.Equals(x.Type, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Value)
                .FirstOrDefault();
        }
    }
}