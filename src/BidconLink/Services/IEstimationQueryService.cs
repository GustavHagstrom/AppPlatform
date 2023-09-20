using SharedLibrary.DTOs.BidconAccess;

namespace BidconLink.Services;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatchDto> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<BC_EstimationBatchDto>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<BC_EstimationDto>> GetEstimationListAsync();
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync();
}