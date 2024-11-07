using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess.Services.DbAccess;

public interface IBidconDbConnectionstringService

{
    Task<string> BuildAsync(ClaimsPrincipal userClaims);
}