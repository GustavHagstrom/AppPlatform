using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ModuleBuilder(IServiceCollection Services)
{
    private readonly AccessIdBuilder _accessIdBuilder = new();

    public ModuleBuilder AddModule<T>() where T : IModule, new()
    {
        var module = new T();
        module.RegisterServices(Services);
        module.RegisterAccessIds(_accessIdBuilder);
        return this;
    }
    internal void Build()
    {
        Services.AddSingleton(new AccessIdContainerService(_accessIdBuilder.Build()));

    }
}
