using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.UserRightSettingsModule;
internal class SettingsLink(IStringLocalizer<SettingsLink> Localizer) : IApplicationLink
{
    public string LinkRoute => Constants.ModuleRoutes.SettingsBasePage;

    public string Text => Localizer["Rättigheter"];

    public string Icon => Icons.Material.Sharp.Security;
}
