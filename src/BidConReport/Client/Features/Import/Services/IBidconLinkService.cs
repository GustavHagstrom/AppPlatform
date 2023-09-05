using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidconLinkService
{
    Task<BC_EstimationBatchDto?> GetBatchAsync(EstimationRequestBatchModelDto request, CancellationToken cancellationToken = default);
    Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(BC_DatabaseCredentialsDto databaseCredentials, CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_EstimationDto>?> GetListAsync(BC_DatabaseCredentialsDto databaseCredentials, CancellationToken cancellationToken = default);
    Task<IEnumerable<BC_EstimationBatchDto>?> GetManyBatchesAsync(EstimationRequestBatchesModelDto request, CancellationToken cancellationToken = default);
}