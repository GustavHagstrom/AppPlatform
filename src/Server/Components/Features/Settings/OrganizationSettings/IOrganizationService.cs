using Server.Enteties;
using System.Security.Claims;

namespace Server.Components.Features.Settings.OrganizationSettings;
public interface IOrganizationService
{
    Task<string?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims);
    Task<IEnumerable<Organization>> GetAllAsync(ClaimsPrincipal userClaims);
    Task SetActiveAsync(ClaimsPrincipal userClaims, Organization organization);
    Task CreateAsync(ClaimsPrincipal userClaims, Organization organization);
}