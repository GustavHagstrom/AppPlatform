using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.UserRightSettingsModule;
internal class UserSettingsLink(IStringLocalizer<UserSettingsLink> Localizer) : IApplicationLink
{
    public string LinkRoute => Constants.ModuleRoutes.UserListPage;

    public string Text => Localizer["Användare"];

    public string Icon => Icons.Material.Sharp.People;
}
