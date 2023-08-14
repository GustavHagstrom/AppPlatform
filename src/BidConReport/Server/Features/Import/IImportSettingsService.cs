using BidConReport.Server.Enteties;

namespace BidConReport.Server.Features.Import;
public interface IImportSettingsService
{
    Task DeleteSettingsAsync(int settingsId);
    Task<ICollection<EstimationImportSettings>> GetOrganizationSettingsAsync(string organizationId);
    Task<EstimationImportSettings?> GetDefaultSettingsAsync(string userId, string organizationId);
    Task SetAsUserDefault(string userId, string organizationId, int? settingsId);
    Task UpsertImportSettingsAsync(EstimationImportSettings settings);
}