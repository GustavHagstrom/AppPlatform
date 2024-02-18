using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.SettingsModule;
public class SettingsModule : IModule
{
    public void RegisterAccessIds(AccessIdBuilder accessIdBuilder)
    {

    }

    public void RegisterServices(IServiceCollection services)
    {
        //services.AddSingleton<IApplicationLink, SettingsMainNavLink>();
    }
}
