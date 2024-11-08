using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess.DbAccess.Services;

public interface IBidconDbConnectionstringService

{
    Task<string> BuildAsync(ClaimsPrincipal userClaims);
}