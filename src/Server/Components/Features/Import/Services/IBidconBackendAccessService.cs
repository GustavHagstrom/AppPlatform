using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.Server.Components.Features.Import.Services;
public interface IBidconBackendAccessService
{
    Task<EstimationBatch?> GetBatchAsync(EstimationRequestBatchModel request, CancellationToken cancellationToken = default);
    Task<EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Estimation>?> GetListAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<EstimationBatch>?> GetManyBatchesAsync(EstimationRequestBatchesModel request, CancellationToken cancellationToken = default);
}