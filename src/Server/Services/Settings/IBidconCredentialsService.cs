using AppPlatform.Server.Enteties;
using System.Security.Claims;

namespace AppPlatform.Server.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims);
    Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentialsDto);
}