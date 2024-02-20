using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Services;
public class ApplicationLinkService : IApplicationLinkService
{
    public ApplicationLinkService(
        [FromKeyedServices(SharedApplicationLinkKeys.MainLayoutLink)] IEnumerable<IApplicationLink> MainLayoutLinks,
        [FromKeyedServices(SharedApplicationLinkKeys.SettingsPageLink)] IEnumerable<IApplicationLink> SettingsPageLinks)
    {
        this.MainLayoutLinks = MainLayoutLinks;
        this.SettingsPageLinks = SettingsPageLinks;
    }

    public IEnumerable<IApplicationLink> MainLayoutLinks { get; }
    public IEnumerable<IApplicationLink> SettingsPageLinks { get; }
}
