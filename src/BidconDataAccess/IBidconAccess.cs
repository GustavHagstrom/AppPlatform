using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Core.Enteties.EstimationEnteties;
using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess;
public interface IBidconAccess
{
    Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims);
    Task<Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims);

}
