﻿using AppPlatform.BidconAccessModule.DirectAccess.Components;
using AppPlatform.BidconAccessModule.DirectAccess.Services;
using AppPlatform.BidconAccessModule.SdkAccess.Components;
using AppPlatform.BidconAccessModule.SdkAccess.Services;
using AppPlatform.BidconAccessModule.Services;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.BidconAccessModule;
public class BidconAccessModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleClaimInfo>();
    }

    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        //When using SDK. (Not reflection)
        //componentBuilder.AddCommonSettingsComponent<BidconSdkCredentials>();

        //When using Direct
        //componentBuilder.AddSettingsComponent<BidconDirectCredentials>();
    }

    public void RegisterServices(IServiceCollection services)
    {
        //when using SDK
        UseSdkReflectionServices(services);

        //when using direct
        //UseDirectServices(services);

        services.AddTransient<IBidconDirectCredentialsService, BidconDirectCredentialsService>();
        services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Authorization.EditBidconConnectionPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
    }


    /// <summary>
    /// Use this when using direct access to DB
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <param name="services"></param>
    private void UseDirectServices(IServiceCollection services)
    {
        services.AddTransient<IBidconDbConnectionstringService, BidconDatabaseConnectionsStringService>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IBidconAccess, BidconDirectDbAccess>();
    }
    /// <summary>
    /// Use this when using SDK access to DB. SDK should be used when client use singel organization with on premis setup.
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <param name="services"></param>
    private void UseSdkServices(IServiceCollection services)
    {
        services.AddTransient<ISdkCredentialsService, SdkCredentialsService>();
        services.AddScoped<IBidconAccess, BidconSdkAccess>();
    }
    private void UseSdkReflectionServices(IServiceCollection services)
    {
        services.AddScoped<IBidconAccess, BidconSdkReflectionAccess>();
        services.AddScoped<IBidconReflectionService, BidconReflectionService>();
    }
}
