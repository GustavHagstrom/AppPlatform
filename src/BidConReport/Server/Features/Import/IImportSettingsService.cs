using BidConReport.Shared.Entities;

namespace BidConReport.Server.Features.Import;
public interface IImportSettingsService
{
    Task DeleteSettingsAsync(int settingsId);
    Task<ICollection<EstimationImportSettings>> GetCurrentOrganizationSettingsAsync(string userId);
    Task<EstimationImportSettings?> GetCurrentsDefaultSettingsAsync(string userId);
    Task SetAsUserDefault(string userId, int? settingsId);
    Task UpsertImportSettingsAsync(EstimationImportSettings settings);
}