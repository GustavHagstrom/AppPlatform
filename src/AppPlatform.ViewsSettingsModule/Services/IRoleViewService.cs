using AppPlatform.Core.Enteties.Authorization;
using AppPlatform.Core.Enteties.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IRoleViewService
{
    Task<IEnumerable<string>> GetPickedRoleIdsAsync(ClaimsPrincipal userClaims, View view);
    Task<IEnumerable<Role>> GetRolesAsync(ClaimsPrincipal userClaims);
    Task PickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> roleIds);
    Task UnpickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> roleIds);
}
