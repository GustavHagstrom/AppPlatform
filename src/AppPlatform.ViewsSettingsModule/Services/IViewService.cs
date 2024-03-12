using AppPlatform.Core.Enteties.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IViewService
{
    Task GetAsync(string viewId);
    Task GetAllAsync(ClaimsPrincipal userClaims);
    Task UpdateAsync(EstimationViewTemplate view);
    Task DeleteAsync(EstimationViewTemplate view);
    Task CreateAsync(ClaimsPrincipal userClaims, EstimationViewTemplate view);

}
