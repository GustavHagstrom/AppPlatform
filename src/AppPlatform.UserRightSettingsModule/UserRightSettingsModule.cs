﻿using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using AppPlatform.UserRightSettingsModule.Components;
using AppPlatform.UserRightSettingsModule.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.UserRightSettingsModule;
public class UserRightSettingsModule : IModule
{
    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IAccessService, AccessService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddAuthorization(configure =>
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
