using SharedLibrary.DTOs.BidconAccess;

namespace Server.Services.Settings;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync(string organizationId);
    Task UpsertAsync(BC_DatabaseCredentialsDto credentialsDto, string organizationId);
}