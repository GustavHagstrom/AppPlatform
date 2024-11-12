using AppPlatform.Shared.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Abstractions;
public interface IModule
{
    void RegisterServices(IServiceCollection services);
    void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder);
    void RegisterApplicationLinks(LinkBuilder applicationLinkBuilder);
    void RegisterInjectableComponents(ComponentBuilder componentBuilder);
}
