using AppPlatform.Shared.Models;
using System.Security.Claims;

namespace AppPlatform.Shared.DataAccess.Authorization;
public interface IAccessClaimStore
{
    Task<IEnumerable<AccessClaim>> GetAccessClaims(ClaimsPrincipal? userClaims);
    Task<IEnumerable<AccessClaim>> GetAccessClaims(string userId);
}