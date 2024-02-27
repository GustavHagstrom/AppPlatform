using AppPlatform.Shared.Abstractions;

namespace AppPlatform.UserRightSettingsModule.Services;
internal interface IUserAccessService
{
    Task<IEnumerable<IAccessClaimInfo>> GetAccessClaims(string userId);
}