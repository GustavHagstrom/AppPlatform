using AppPlatform.BidconBrowserModule.Models;
using System.Security.Claims;

namespace AppPlatform.BidconBrowserModule.Services;
internal interface IBidconBrowserAccesService
{
    Task<TreeItem> GetTreeItemRootAsync(ClaimsPrincipal userClaims);
}
