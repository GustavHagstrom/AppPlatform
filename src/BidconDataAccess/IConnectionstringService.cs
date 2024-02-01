using System.Security.Claims;

namespace AppPlatform.BidconDataAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync(ClaimsPrincipal userClaims);
}