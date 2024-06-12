using AppPlatform.Core.Enteties.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IViewService
{
    Task GetAsync(string viewId);
    Task GetAllAsync(ClaimsPrincipal userClaims);
    Task DeleteAsync(View view);
    Task UpsertAsync(ClaimsPrincipal userClaims, View view);
    Task<List<View>> GetViewListAsync(ClaimsPrincipal UserClaims);
}
