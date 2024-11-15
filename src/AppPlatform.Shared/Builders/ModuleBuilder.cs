using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ModuleBuilder(IServiceCollection Services)
{
    private readonly AccessClaimInfoBuilder _accessIdBuilder = new(Services);
    private readonly ComponentBuilder _componentBuilder = new(Services);

    public void AddModule<T>() where T : IModule, new()
    {
        var module = new T();
        module.RegisterServices(Services);
        module.RegisterAccessIds(_accessIdBuilder);
        module.RegisterInjectableComponents(_componentBuilder);
    }
}
