using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Services;

public interface IImportSettingsService
{
    Task<IEnumerable<EstimationImportSettings>> GetAllAsync();
    Task<EstimationImportSettings> GetStandardAsync();
}
