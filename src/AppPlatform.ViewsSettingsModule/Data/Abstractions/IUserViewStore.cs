using AppPlatform.Core.Models.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Data.Abstractions;
internal interface IUserViewStore
{
    Task<IEnumerable<string>> GetPickedUserIdsAsync(View view);
    Task PickAsync(View view, IEnumerable<string> userIds);
    Task UnpickAsync(View view, IEnumerable<string> userIds);
}