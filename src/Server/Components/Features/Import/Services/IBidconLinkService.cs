using AppPlatform.BidconDataAccess.Models;

namespace AppPlatform.Server.Components.Features.Import.Services;
public interface IBidconLinkService
{
    Task<BC_EstimationBatch?> GetBatchAsync(EstimationRequestBatchModel request, CancellationToken cancellationToken = default);
    Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_Estimation>?> GetListAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_EstimationBatch>?> GetManyBatchesAsync(EstimationRequestBatchesModel request, CancellationToken cancellationToken = default);
}