using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess;

public interface IConnectionstringService
{
    Task<string> BuildAsync(ClaimsPrincipal userClaims);
}