using AppPlatform.BidconDatabaseAccess.Models;
using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess.Services.DbAccess;
public interface IEstimationQueryService
{
    Task<D_EstimationBatch> GetEstimationBatchAsync(string estimationId, ClaimsPrincipal userClaims);
    Task<IEnumerable<D_EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, ClaimsPrincipal userClaims);
    Task<IEnumerable<D_Estimation>> GetEstimationListAsync(ClaimsPrincipal userClaims);
    Task<D_EstimationFolderBatch> GetFolderBatchAsync(ClaimsPrincipal userClaims);
}