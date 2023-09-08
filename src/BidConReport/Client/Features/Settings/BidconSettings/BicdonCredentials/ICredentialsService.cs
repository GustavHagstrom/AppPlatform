using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Features.Settings.BidconSettings.BicdonCredentials;
public interface ICredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync();
    Task UpsertAsync(BC_DatabaseCredentialsDto credentials);
}