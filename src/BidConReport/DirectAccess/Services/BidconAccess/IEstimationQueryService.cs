using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.QueryResults;

namespace BidConReport.BidconAccess.Services.BidconAccess;
public interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds);
    Task<IEnumerable<EstimationResult>> GetEstimationListAsync();
    Task<EstimationFolderBatch> GetFolderBatchAsync();
}