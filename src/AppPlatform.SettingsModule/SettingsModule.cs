using AppPlatform.Shared.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.SettingsModule;
public class SettingsModule : ModuleBase
{
    protected override void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IMainNavigationLink, SettingsNavLink>();
    }
}
