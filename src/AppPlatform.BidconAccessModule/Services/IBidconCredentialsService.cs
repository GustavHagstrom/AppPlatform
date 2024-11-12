using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.Services;
public interface IBidconCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims);
    Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentialsDto);
}