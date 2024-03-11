using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.BidconAccessModule;
public class BidconAccessModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        throw new NotImplementedException();
    }

    public void RegisterApplicationLinks(LinkBuilder applicationLinkBuilder)
    {
        throw new NotImplementedException();
    }

    public void RegisterServices(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}
