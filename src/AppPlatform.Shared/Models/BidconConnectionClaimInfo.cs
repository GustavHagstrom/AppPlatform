using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.Localization;

namespace AppPlatform.Shared.Models;
internal class BidconConnectionClaimInfo(IStringLocalizer<BidconConnectionClaimInfo> Localizer) : IAccessClaimInfo
{
    public string Value => SharedAccessClaimValues.BidconConnection;

    public string Name => Localizer["Bidconanslutning"];

    public string Description => Localizer["Ändra inställningar för anslutningen mot Bidcons databas."];
}
