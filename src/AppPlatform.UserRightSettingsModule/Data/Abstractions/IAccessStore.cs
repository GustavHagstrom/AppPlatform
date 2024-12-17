using AppPlatform.Core.Models.Authorization;


namespace AppPlatform.UserRightSettingsModule.Data.Abstractions;
internal interface IAccessStore
{
    Task<IEnumerable<UserAccess>> GetUserAccessClaimValuesAsync(string userId);
    Task<IEnumerable<RoleAccess>> GetRoleAccessClaimValuesAsync(string roleId);
    Task CreateUserAccessAsync(UserAccess userAccess);
    Task CreateRoleAccessAsync(RoleAccess roleAccess);
    Task DeleteUserAccessAsync(UserAccess userAccess);
    Task DeleteRoleAccessAsync(RoleAccess roleAccess);
}