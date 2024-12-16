using AppPlatform.Core.Models.EstimationEnteties;
using System.Security.Claims;
using AppPlatform.Core.Models.FromShared;

namespace AppPlatform.Core.Abstractions;
public interface IBidconAccess
{
    Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims);
    Task<Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims);

}
