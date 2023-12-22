using Server.Enteties;
using System.Security.Claims;

namespace Server.Components.Features.Settings.OrganizationSettings;
public interface IOrganizationService
{
    Task<Guid?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims);
    Task<IEnumerable<Enteties.Organization>> GetAllAsync(ClaimsPrincipal userClaims);
    Task SetActiveAsync(ClaimsPrincipal userClaims, Organization organization);
}