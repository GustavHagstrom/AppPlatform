using AppPlatform.Core.DTOs.BidconAccess;
using System.Security.Claims;

namespace AppPlatform.BidconDataAccess;
public interface IEstimationQueryService
{
    Task<BC_EstimationBatchDto> GetEstimationBatchAsync(string estimationId, ClaimsPrincipal userClaims);
    Task<IEnumerable<BC_EstimationBatchDto>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, ClaimsPrincipal userClaims);
    Task<IEnumerable<BC_EstimationDto>> GetEstimationListAsync(ClaimsPrincipal userClaims);
    Task<BC_EstimationFolderBatch> GetFolderBatchAsync(ClaimsPrincipal userClaims);
}