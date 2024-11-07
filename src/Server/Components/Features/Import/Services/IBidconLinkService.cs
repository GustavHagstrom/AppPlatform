using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.Server.Components.Features.Import.Services;
public interface IBidconLinkService
{
    Task<D_EstimationBatch?> GetBatchAsync(D_EstimationRequestBatchModel request, CancellationToken cancellationToken = default);
    Task<D_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<D_Estimation>?> GetListAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<D_EstimationBatch>?> GetManyBatchesAsync(D_EstimationRequestBatchesModel request, CancellationToken cancellationToken = default);
}