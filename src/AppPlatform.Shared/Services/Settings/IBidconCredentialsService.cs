using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.Shared.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims);
    Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentialsDto);
}