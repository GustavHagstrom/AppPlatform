using AppPlatform.Shared.Abstractions;
using Microsoft.AspNetCore.Builder;

namespace AppPlatform.Shared.Builders;
public class ModuleBuilder(WebApplicationBuilder builder)
{
    private readonly AccessClaimInfoBuilder _accessIdBuilder = new(builder.Services);
    private readonly ComponentBuilder _componentBuilder = new(builder.Services);

    public void AddModule<T>() where T : IModule, new()
    {
        var module = new T();
        module.Configure(builder);
        module.RegisterAccessIds(_accessIdBuilder);
        module.RegisterInjectableComponents(_componentBuilder);
    }
}
