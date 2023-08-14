using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettings>> GetAllAsync();
    Task<EstimationImportSettings?> GetDefaultAsync();
    Task UpsertAsync(EstimationImportSettings settings);
    Task DeleteAsync(int settingsId);
    Task SaveAsDefaultAsync(EstimationImportSettings? settings);
}
