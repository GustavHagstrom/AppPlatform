using SharedLibrary.DTOs.BidconAccess;

namespace Server.Services;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync();
    Task UpsertAsync(BC_DatabaseCredentialsDto credentials);
}