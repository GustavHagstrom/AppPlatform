﻿using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace AppPlatform.ViewSettingsModule;
internal class SettingsLink(IStringLocalizer<SettingsLink> Localizer) : IApplicationLink
{
    public string LinkRoute => Constants.Routes.SettingsBasePage;

    public string Text => Localizer["Kalkylvyer"];

    public string Icon => Icons.Material.Sharp.Pageview;

    public string? AuthPolicy => Constants.Authorization.Policy;
}
