using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using AppPlatform.UserRightSettingsModule.Components;
using AppPlatform.UserRightSettingsModule.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.UserRightSettingsModule;
public class UserRightSettingsModule : IModule
{
    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccessService, AccessService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy(Constants.AuthorizationConstants.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.AuthorizationConstants.AccessClaimValue);
            });
        });
    }

    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleAccessClaimInfo>();
    }
    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        componentBuilder.AddSettingsNavigationComponent<SettingsLink>();
    }
}
