﻿using AppPlatform.Core.Services;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Components.Settings;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Models;
using AppPlatform.Shared.Services;
using AppPlatform.Shared.Services.Authorization;
using AppPlatform.Shared.Services.MicrosoftGraph;
using AppPlatform.Shared.Services.Settings;
using AppPlatform.Shared.Services.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Authentication;

namespace AppPlatform.Shared.Extensions;
public static class HostApplicationBuilderExtensions
{

    public static void AddModules(this IServiceCollection services, Action<ModuleBuilder> configure)
    {
        var moduleBuilder = new ModuleBuilder(services);
        configure(moduleBuilder);
    }
    public static void AddApplicationInjectableComponent<T>(this IServiceCollection services, string key) where T : class, IInjectableComponent
    {
        services.AddKeyedTransient<IInjectableComponent, T>(key);
    }
    public static void AddAccessClaimInfo<T>(this IServiceCollection services) where T : class, IAccessClaimInfo
    {
        services.AddSingleton<IAccessClaimInfo, T>();
    }
    /// <summary>
    /// Should only be called once in the application
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterSharedServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        services.AddTransient<IAccessClaimService, AccessClaimService>();
        services.AddSingleton<IApplicationRenderComponentsService, ApplicationRenderComponentsService>();
        services.AddApplicationInjectableComponent<AppbarSettingsLink>(SharedInjectableComponentKeys.AppBarNavLinkComponent);
        services.AddSingleton<IAccessClaimInfoContainer, AccessClaimInfoContainer>();
        services.AddAccessClaimInfo<BidconConnectionClaimInfo>();
        services.AddTransient<IAuthenticationProvider, GraphClientAuthProvider>();
        services.AddScoped(sp => new GraphServiceClient(sp.GetRequiredService<IAuthenticationProvider>()));
        services.AddScoped<IMicrosoftGraphUserAccess, GraphClientUserAccess>();
        services.AddTransient<IViewStyleService, ViewStyleService>();


        //Core services
        services.AddScoped<ISheetDataService, SheetDataService>();

        services.AddAuthorization(configure =>
        {
            configure.AddPolicy(SharedAuthorizationPolicies.BidconConnection, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, SharedAccessClaimValues.BidconConnection);
            });
        });
    }
}
