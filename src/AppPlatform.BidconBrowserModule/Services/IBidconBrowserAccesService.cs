using AppPlatform.BidconBrowserModule.Models;

namespace AppPlatform.BidconBrowserModule.Services;
internal interface IBidconBrowserAccesService
{
    Task<TreeItem> GetTreeItemRootAsync();
}
