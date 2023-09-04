using BidConReport.Client.Shared.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.BidconAccess.Services;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatch> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<BC_EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<BC_Estimation>> GetEstimationListAsync();
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync();
}