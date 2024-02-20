using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ModuleBuilder(IServiceCollection Services)
{
    private readonly AccessIdBuilder _accessIdBuilder = new();
    private readonly LinkBuilder _applicationLinkBuilder = new(Services);

    public ModuleBuilder AddModule<T>() where T : IModule, new()
    {
        var module = new T();
        module.RegisterServices(Services);
        module.RegisterAccessIds(_accessIdBuilder);
        module.RegisterApplicationLinks(_applicationLinkBuilder);
        return this;
    }
    internal void Build()
    {
        var accessIdContainerImplementation = new AccessIdContainerService(_accessIdBuilder.Build());
        Services.AddSingleton<IAccessIdContainerService>(accessIdContainerImplementation);
    }
}
