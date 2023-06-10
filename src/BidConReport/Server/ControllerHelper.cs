using BidConReport.Shared;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace BidConReport.Server;

public static class ControllerHelper
{
    public static Claim? GetOrganizationClaim(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == ClaimConstants.TenantId).FirstOrDefault();
    }
    public static Claim? GetUserIdClaim(ClaimsPrincipal user)
    {
        return user.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault();
    }
}
