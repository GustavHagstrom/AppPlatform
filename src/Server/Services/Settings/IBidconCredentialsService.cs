using SharedLibrary.DTOs.BidconAccess;
using System.Security.Claims;

namespace Server.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync(ClaimsPrincipal user);
    Task UpsertAsync(ClaimsPrincipal user, BC_DatabaseCredentialsDto credentialsDto);
}