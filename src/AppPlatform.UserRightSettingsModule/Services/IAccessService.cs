using AppPlatform.Core.Enteties.Authorization;
using System.Security.Claims;

namespace AppPlatform.UserRightSettingsModule.Services;
internal interface IAccessService
{
    Task<IEnumerable<UserAccess>> GetUserAccessClaimValuesAsync(string userId);
    Task<IEnumerable<RoleAccess>> GetRoleAccessClaimValuesAsync(string roleId);
    Task CreateUserAccessAsync(UserAccess userAccess);
    Task CreateRoleAccessAsync(RoleAccess roleAccess);
    Task DeleteUserAccessAsync(UserAccess userAccess);
    Task DeleteRoleAccessAsync(RoleAccess roleAccess);
}