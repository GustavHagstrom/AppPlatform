﻿using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;

namespace AppPlatform.ViewSettingsModule;
internal class ViewSettingsClaimInfo(IStringLocalizer<ViewSettingsClaimInfo> Localizer) : IAccessClaimInfo
{
    public string Value => AuthorizationConstants.AccessClaimValue;

    public string Name => Localizer["Vy inställningar"];

    public string Description => Localizer["Rättighet att skapa, ändra och ta bort kalkylvyer."];
}
