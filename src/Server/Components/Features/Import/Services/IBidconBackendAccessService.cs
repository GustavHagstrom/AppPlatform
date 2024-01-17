using SharedLibrary.DTOs.BidconAccess;

namespace AppPlatform.Server.Components.Features.Import.Services;
public interface IBidconBackendAccessService
{
    Task<BC_EstimationBatchDto?> GetBatchAsync(EstimationRequestBatchModelDto request, CancellationToken cancellationToken = default);
    Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_EstimationDto>?> GetListAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_EstimationBatchDto>?> GetManyBatchesAsync(EstimationRequestBatchesModelDto request, CancellationToken cancellationToken = default);
}