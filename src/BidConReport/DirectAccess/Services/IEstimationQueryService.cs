using BidConReport.BidconAccess.Enteties;

namespace BidConReport.BidconAccess.Services;
public interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<Estimation>> GetEstimationListAsync();
    Task<EstimationFolderBatch> GetFolderBatchAsync();
}