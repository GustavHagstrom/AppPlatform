using BidConReport.Shared.Entities;

namespace BidConReport.Client.Features.Import.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettings>> GetAllAsync();
    Task<EstimationImportSettings> GetDefaultAsync();
    Task UpsertAsync(EstimationImportSettings settings);
    Task DeleteAsync(int settingsId);
    Task SaveAsDefaultAsync(EstimationImportSettings? settings);
}
