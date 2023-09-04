using BidConReport.Client.Shared.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.BidconAccess.Services;
public interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<BC_Estimation>> GetEstimationListAsync();
    Task<EstimationFolderBatch> GetFolderBatchAsync();
}