using System.Security.Claims;

namespace AppPlatform.Shared.Services.Authorization;
public interface IAccessClaimService
{
    Task<IEnumerable<AccessClaim>> GetAccessClaims(ClaimsPrincipal? userClaims);
}