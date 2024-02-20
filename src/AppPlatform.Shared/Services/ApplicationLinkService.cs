using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Services;
public class ApplicationLinkService : IApplicationLinkService
{
    public ApplicationLinkService([FromKeyedServices(SharedApplicationLinkKeys.MainLayoutLink)] IEnumerable<IApplicationLink> MainLayoutLinks)
    {
        this.MainLayoutLinks = MainLayoutLinks;
    }

    public IEnumerable<IApplicationLink> MainLayoutLinks { get; }
}
