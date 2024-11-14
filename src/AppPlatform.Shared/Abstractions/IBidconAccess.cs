using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Shared.Models;
using System.Security.Claims;

namespace AppPlatform.Shared.Abstractions;
public interface IBidconAccess
{
    Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims);
    Task<Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims);

}
