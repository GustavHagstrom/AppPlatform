using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.SettingsModule;
internal class SettingsMainNavLink(IStringLocalizer<SettingsMainNavLink> localizer) : IApplicationLink
{
    public string LinkRoute => ModuleRoutes.Start;

    public string Text => localizer["Inställningar"];

    public string Icon => Icons.Material.Sharp.Settings;
}
