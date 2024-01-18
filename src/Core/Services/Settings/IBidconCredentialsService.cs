using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.Core.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims);
    Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentialsDto);
}