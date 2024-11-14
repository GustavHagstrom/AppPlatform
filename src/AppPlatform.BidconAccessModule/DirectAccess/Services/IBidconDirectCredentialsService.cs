using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Services;
public interface IBidconDirectCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims);
    Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentialsDto);
}