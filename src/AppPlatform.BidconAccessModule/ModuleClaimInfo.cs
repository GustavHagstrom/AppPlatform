using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.Localization;

namespace AppPlatform.BidconAccessModule;
internal class ModuleClaimInfo(IStringLocalizer<ModuleClaimInfo> Localizer) : IAccessClaimInfo
{
    public string Value => Constants.Authorization.AccessClaimValue;

    public string Name => Localizer["BidconAnslutning"];

    public string Description => Localizer["Tillåts att modifiera Bidcon-anslutning"];
}
