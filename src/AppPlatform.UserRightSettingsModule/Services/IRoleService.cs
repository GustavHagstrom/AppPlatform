using AppPlatform.Core.Enteties.Authorization;
using System.Security.Claims;

namespace AppPlatform.UserRightSettingsModule.Services;
internal interface IRoleService
{
    Task<Role?> GetRoleAsync(string roleId);
    Task<List<Role>> GetRolesAsync(ClaimsPrincipal user);
    Task UpsertRoleAsync(ClaimsPrincipal userClaims, Role role);
    Task DeleteRoleAsync(Role role);
    Task<List<Role>> GetRolesForUserAsync(string userId);
    Task<List<UserRole>> GetUserRolesForRoleAsync(string roleId);
}
