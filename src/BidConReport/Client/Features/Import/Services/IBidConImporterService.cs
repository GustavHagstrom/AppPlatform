using BidConReport.Shared.Entities;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidConImporterService
{
    Task<IEnumerable<BidConImportResult<Estimation>>> GetEstimationsAsync(IEnumerable<DbEstimation> estimations, EstimationImportSettings settings, CancellationToken cancelToken, IProgress<BidConImportResult<Estimation>>? progress = null);
    Task<BidConImportResult<Estimation>> GetEstimationAsync(BidconImportRequest request, CancellationToken cancelToken);
    Task<BidConImportResult<DbFolder>> GetFoldersAsync();
}