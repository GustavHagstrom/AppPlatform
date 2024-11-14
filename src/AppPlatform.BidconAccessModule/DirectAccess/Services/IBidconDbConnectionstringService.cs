using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Services;

public interface IBidconDbConnectionstringService

{
    Task<string> BuildAsync(ClaimsPrincipal userClaims);
}