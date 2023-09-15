using SharedLibrary.DTOs.BidconAccess;

namespace BidconLink.Services;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatchDto> GetEstimationBatchAsync(string estimationId, BC_DatabaseCredentialsDto credentials);
    Task<IEnumerable<BC_EstimationBatchDto>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, BC_DatabaseCredentialsDto credentials);
    Task<IEnumerable<BC_EstimationDto>> GetEstimationListAsync(BC_DatabaseCredentialsDto credentials);
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync(BC_DatabaseCredentialsDto credentials);
}