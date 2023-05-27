using BidConReport.Shared;
using System.Security.Claims;

namespace BidConReport.Server;

public static class ControllerHelper
{
    public static Claim? GetOrganizationClaim(ClaimsPrincipal user)
    {
        var a = user.Claims.ToList();
        return user.Claims.Where(x => x.Type == AppConstants.OrganizationIdClaimKey).FirstOrDefault();
    }
    public static Claim? GetUserIdClaim(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == AppConstants.UserIdClaimKey).FirstOrDefault();
    }
}
