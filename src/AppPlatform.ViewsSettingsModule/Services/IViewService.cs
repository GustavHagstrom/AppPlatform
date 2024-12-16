using AppPlatform.Core.Models.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IViewService
{
    Task<View?> GetAsync(ClaimsPrincipal userClaims, string viewId);
    Task DeleteAsync(ClaimsPrincipal userClaims, View view);
    Task UpsertAsync(ClaimsPrincipal userClaims, View view);
    Task<List<View>> GetViewListAsync(ClaimsPrincipal UserClaims);
}
