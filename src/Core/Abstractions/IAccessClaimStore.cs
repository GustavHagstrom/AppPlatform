using AppPlatform.Core.Models.FromShared;
using System.Security.Claims;

namespace AppPlatform.Core.Abstractions;
public interface IAccessClaimStore
{
    Task<IEnumerable<AccessClaim>> GetAccessClaims(ClaimsPrincipal? userClaims);
    Task<IEnumerable<AccessClaim>> GetAccessClaims(string userId);
}