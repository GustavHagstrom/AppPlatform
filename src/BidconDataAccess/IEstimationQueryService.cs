using AppPlatform.BidconDataAccess.Models;
using System.Security.Claims;

namespace AppPlatform.BidconDataAccess;
public interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId, ClaimsPrincipal userClaims);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, ClaimsPrincipal userClaims);
    Task<IEnumerable<Estimation>> GetEstimationListAsync(ClaimsPrincipal userClaims);
    Task<EstimationFolderBatch> GetFolderBatchAsync(ClaimsPrincipal userClaims);
}