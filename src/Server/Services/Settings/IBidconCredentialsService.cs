using Server.Enteties;
using System.Security.Claims;

namespace Server.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal user);
    Task UpsertAsync(ClaimsPrincipal user, BidconAccessCredentials credentialsDto);
}