using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.UserRightSettingsModule;
internal class RoleSettingsLink(IStringLocalizer<UserSettingsLink> Localizer) : IApplicationLink
{

    public string Text => Localizer["Roller"];

    public string Icon => Icons.Material.Sharp.AdminPanelSettings;

    public string LinkRoute => Constants.ModuleRoutes.RoleListPage;
}
