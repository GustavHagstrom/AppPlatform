using SharedLibrary.DTOs.BidconAccess;

namespace Client.Shared.Services;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync();
    Task UpsertAsync(BC_DatabaseCredentialsDto credentials);
}