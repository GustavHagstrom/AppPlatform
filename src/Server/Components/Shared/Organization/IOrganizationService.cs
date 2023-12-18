using System.Security.Claims;

namespace Server.Components.Shared.Organization;
public interface IOrganizationService
{
    Task<Guid?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims);
    Task<IEnumerable<Enteties.Organization>> GetAllAsync(ClaimsPrincipal userClaims);
    Task SetActiveAsync(ClaimsPrincipal userClaims, Enteties.Organization organization);
}