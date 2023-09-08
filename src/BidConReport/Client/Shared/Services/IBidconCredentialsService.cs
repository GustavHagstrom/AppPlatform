using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Shared.Services;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync();
    Task UpsertAsync(BC_DatabaseCredentialsDto credentials);
}