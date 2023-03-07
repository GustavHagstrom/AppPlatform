using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettings>> GetAllAsync();
    Task<EstimationImportSettings> GetStandardAsync();
    Task UpsertAsync(EstimationImportSettings settings);
    Task DeleteAsync(int settingsId);
}
