using AppPlatform.Core.Enteties.Authorization;
using System.Security.Claims;

namespace AppPlatform.UserRightSettingsModule.Services;
internal interface IRoleService
{
    Task<Role?> GetRoleAsync(string roleId);
    Task<List<Role>> GetRolesAsync(ClaimsPrincipal user);
    Task UpsertRoleAsync(ClaimsPrincipal userClaims, Role role);
    Task DeleteRoleAsync(Role role);
    Task<List<Role>> GetUserRolesForUserAsync(string userId);
    Task<List<UserRole>> GetUserRolesForRoleAsync(string roleId);
    Task CreateUserRole(ClaimsPrincipal userClaims, Role role);
    Task DeleteUserRole(ClaimsPrincipal userClaims, Role role);
    Task CreateUserRole(UserRole userRole);
    Task DeleteUserRole(UserRole userRole);
}
