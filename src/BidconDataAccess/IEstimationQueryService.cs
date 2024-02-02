using AppPlatform.BidconDataAccess.Models;
using System.Security.Claims;

namespace AppPlatform.BidconDataAccess;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatch> GetEstimationBatchAsync(string estimationId, ClaimsPrincipal userClaims);
    Task<IEnumerable<BC_EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, ClaimsPrincipal userClaims);
    Task<IEnumerable<BC_Estimation>> GetEstimationListAsync(ClaimsPrincipal userClaims);
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync(ClaimsPrincipal userClaims);
}