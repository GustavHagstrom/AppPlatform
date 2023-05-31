using BidConReport.Shared.Entities;

namespace BidConReport.Client.Features.Import.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettings>> GetAllAsync();
    Task<EstimationImportSettings> GetStandardAsync();
    Task UpsertAsync(EstimationImportSettings settings);
    Task DeleteAsync(int settingsId);
    Task SaveAsStandardAsync(EstimationImportSettings? settings);
}
