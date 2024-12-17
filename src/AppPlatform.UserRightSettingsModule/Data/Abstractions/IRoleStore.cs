using AppPlatform.Core.Models.Authorization;

namespace AppPlatform.UserRightSettingsModule.Data.Abstractions;
internal interface IRoleStore
{
    Task<Role?> GetRoleAsync(string roleId);
    Task<List<Role>> GetRolesAsync(string tenantId);
    Task UpsertRoleAsync(string tenantId, Role role);
    Task DeleteRoleAsync(Role role);
    Task<List<Role>> GetUserRolesForUserAsync(string userId);
    Task<List<UserRole>> GetUserRolesForRoleAsync(string roleId);
    Task CreateUserRole(string userId, Role role);
    Task DeleteUserRole(string userId, Role role);
    Task CreateUserRole(UserRole userRole);
    Task DeleteUserRole(UserRole userRole);
}
