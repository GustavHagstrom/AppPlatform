using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.Shared;
internal class SettingsMainNavLink(IStringLocalizer<SettingsMainNavLink> localizer) : IApplicationLink
{
    public string LinkRoute => SharedRoutes.Start;

    public string Text => localizer["Inställningar"];

    public string Icon => Icons.Material.Sharp.Settings;

    public string? AuthPolicy => null;
}
