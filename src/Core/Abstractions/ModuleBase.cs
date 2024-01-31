using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppPlatform.Core.Abstractions;
public abstract class ModuleBase
{
    public void AddModule(IHostApplicationBuilder builder)
    {
        RegisterServices(builder.Services);
    }
    protected abstract void RegisterServices(IServiceCollection services);
}
