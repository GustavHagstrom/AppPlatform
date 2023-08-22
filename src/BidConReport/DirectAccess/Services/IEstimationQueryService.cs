using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;

namespace BidConReport.DirectAccess.Services;
public interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<EstimationResult>> GetEstimationListAsync();
    Task<EstimationFolderBatch> GetFolderBatchAsync();
}