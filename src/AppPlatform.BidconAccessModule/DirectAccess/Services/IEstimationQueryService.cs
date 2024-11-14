using AppPlatform.BidconAccessModule.DirectAccess.Models;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Services;
internal interface IEstimationQueryService
{
    Task<EstimationBatch> GetEstimationBatchAsync(string estimationId, ClaimsPrincipal userClaims);
    Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, ClaimsPrincipal userClaims);
    Task<IEnumerable<B_Estimation>> GetEstimationListAsync(ClaimsPrincipal userClaims);
    Task<EstimationFolderBatch> GetFolderBatchAsync(ClaimsPrincipal userClaims);
}