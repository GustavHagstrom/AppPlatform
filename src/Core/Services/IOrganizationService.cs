using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.Core.Services;
public interface IOrganizationService
{
    Task<string?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims);
    Task<IEnumerable<Organization>> GetAllAsync(ClaimsPrincipal userClaims);
    Task SetActiveAsync(ClaimsPrincipal userClaims, Organization? organization);
    Task CreateAsync(ClaimsPrincipal userClaims, Organization organization);
    Task UpdateAsync(ClaimsPrincipal userClaims, Organization organization);
}