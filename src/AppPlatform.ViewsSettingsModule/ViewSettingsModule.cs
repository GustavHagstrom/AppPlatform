using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using AppPlatform.ViewSettingsModule.Components;
using AppPlatform.ViewSettingsModule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.ViewSettingsModule;
public class ViewSettingsModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder builder)
    {
        builder.AddAccessClaimInfo<ViewSettingsClaimInfo>();
    }
    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        componentBuilder.AddSettingsNavigationComponent<SettingsLink>();
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IViewService, ViewService>();
        services.AddScoped<IRoleViewService, RoleViewService>();
        services.AddScoped<IUserViewService, UserViewService>();
        services.AddSingleton<Helper>();
        services.AddAuthorization(configure =>
        {
            configure.AddPolicy(Constants.Authorization.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
        });
    }
}
