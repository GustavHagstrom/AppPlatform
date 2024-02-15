using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.SettingsModule;
public class SettingsModule : IModule
{
    public void RegisterAccessIds(AccessIdBuilder accessIdBuilder)
    {

    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMainNavigationLink, SettingsNavLink>();
    }
}
