using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Core.Abstractions;
public abstract class ModuleBase
{
    public void AddModule(IServiceCollection services)
    {
        RegisterServices(services);
    }
    protected abstract void RegisterServices(IServiceCollection services);
}
