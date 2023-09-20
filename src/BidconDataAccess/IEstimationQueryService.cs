using SharedLibrary.DTOs.BidconAccess;

namespace BidconDataAccess;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatchDto> GetEstimationBatchAsync(string estimationId, string? organization = null);
    Task<IEnumerable<BC_EstimationBatchDto>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, string? organization = null);
    Task<IEnumerable<BC_EstimationDto>> GetEstimationListAsync(string? organization = null);
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync(string? organization = null);
}