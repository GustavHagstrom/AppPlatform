using AppPlatform.Shared.Builders;
using Microsoft.AspNetCore.Builder;

namespace AppPlatform.Shared.Abstractions;
public interface IModule
{
    void Configure(WebApplicationBuilder builder);
    void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder);
    void RegisterInjectableComponents(ComponentBuilder componentBuilder);
}
