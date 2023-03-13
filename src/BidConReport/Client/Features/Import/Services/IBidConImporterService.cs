using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidConImporterService
{
    Task<IEnumerable<BidConImportResult<Estimation>>> GetEstimationsAsync(IEnumerable<string> ids, EstimationImportSettings settings, IProgress<BidConImportResult<Estimation>>? progress = null);
    Task<BidConImportResult<Estimation>> GetEstimationAsync(string ids, EstimationImportSettings settings);
    Task<BidConImportResult<DbFolder>> GetFoldersAsync();
}