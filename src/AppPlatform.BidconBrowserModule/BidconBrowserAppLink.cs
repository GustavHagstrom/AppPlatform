using AppPlatform.Shared;
using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.BidconBrowserModule;
internal class BidconBrowserAppLink(IStringLocalizer<BidconBrowserAppLink> Localizer) : IApplicationLink
{
    public string LinkRoute => Constants.ModuleRoutes.BidconBrowser;

    public string Text => Localizer["Kalkylutforskaren"];

    public string Icon => CustomIcons.BidconIcon;

    public string? AuthPolicy => Constants.Authorization.Policy;
}
