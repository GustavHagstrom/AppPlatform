using AppPlatform.BidconAccessModule.DirectAccess.Services;
using AppPlatform.BidconAccessModule.SdkAccess.Services;
using AppPlatform.BidconAccessModule.Services;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

    public void GeneralConfig(WebApplicationBuilder builder)
    {
        //when using SDK
        UseSdkReflectionServices(builder.Services);

        //when using direct
        //UseDirectServices(services);

        
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Authorization.EditBidconConnectionPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
    }
    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBidconDirectCredentialsService, BidconDirectCredentialsService>();
    }

    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionBuilder collectionBuilder)
    {

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

    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
}
