using AppPlatform.Core.Enteties.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IUserViewService
{
    Task<IEnumerable<string>> GetPickedUserIdsAsync(ClaimsPrincipal userClaims, View view);
    Task PickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> userIds);
    Task UnpickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> userIds);
}