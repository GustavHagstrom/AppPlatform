using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppPlatform.Core.Abstractions;
public abstract class ModuleBase
{
    public void AddModule(IServiceCollection services)
    {
        RegisterServices(services);
    }
    protected abstract void RegisterServices(IServiceCollection services);
}
