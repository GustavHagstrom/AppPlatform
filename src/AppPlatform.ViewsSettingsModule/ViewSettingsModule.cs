using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using AppPlatform.ViewSettingsModule.Components;
using AppPlatform.ViewSettingsModule.Services;
using Microsoft.AspNetCore.Builder;
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

    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IViewService, ViewService>();
        builder.Services.AddScoped<IRoleViewService, RoleViewService>();
        builder.Services.AddScoped<IUserViewService, UserViewService>();
        builder.Services.AddSingleton<Helper>();
        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy(Constants.Authorization.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
        });
    }
}
