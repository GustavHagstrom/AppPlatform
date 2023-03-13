using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidConImporterService
{
    Task<IEnumerable<BidConImportResult<Estimation>>> GetEstimationsAsync(IEnumerable<DbEstimation> estimations, EstimationImportSettings settings, IProgress<BidConImportResult<Estimation>>? progress = null);
    Task<BidConImportResult<Estimation>> GetEstimationAsync(BidconImportRequest request);
    Task<BidConImportResult<DbFolder>> GetFoldersAsync();
}