﻿using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;

namespace AppPlatform.ViewSettingsModule;
internal class ViewSettingsClaimInfo(IStringLocalizer<ViewSettingsClaimInfo> Localizer) : IAccessClaimInfo
{
    public string Value => Constants.Authorization.AccessClaimValue;

    public string Name => Localizer["Vy inställningar"];

    public string Description => Localizer["Skapa, ändra och ta bort kalkylvyer."];
}
