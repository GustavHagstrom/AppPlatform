using AppPlatform.BidconBrowserModule.Models;
using AppPlatform.Core.Abstractions;
using System.Security.Claims;

namespace AppPlatform.BidconBrowserModule.Services;
internal class BidconBrowserAccesService(IBidconAccess bidconAccess) : IBidconBrowserAccesService
{
    public async Task<TreeItem> GetTreeItemRootAsync(string tenantId)
    {
        var folder = await bidconAccess.GetFolderRootAsync(tenantId);
        return new TreeItem(folder);
    }
}
