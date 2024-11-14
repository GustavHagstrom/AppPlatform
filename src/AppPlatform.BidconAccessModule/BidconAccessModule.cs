using AppPlatform.BidconAccessModule.DirectAccess.Components;
using AppPlatform.BidconAccessModule.DirectAccess.Services;
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

    public void RegisterApplicationLinks(LinkBuilder applicationLinkBuilder)
    {

    }

    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        //When using SDK
        //componentBuilder.AddSettingsComponent<BidconSdkCredentials>();

        //When using Direct
        componentBuilder.AddSettingsComponent<BidconDirectCredentials>();



    }

    public void RegisterServices(IServiceCollection services)
    {
        //when using SDK
        //UseSdkServices<?????>(services);

        //when using direct
        UseDirectServices<BidconDatabaseConnectionsStringService>(services);

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
    private void UseDirectServices<TImplementation>(IServiceCollection services) where TImplementation : class, IBidconDbConnectionstringService
    {
        services.AddTransient<IBidconDbConnectionstringService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IBidconAccess, BidconDirectDbAccess>();
    }
    /// <summary>
    /// Use this when using SDK access to DB
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <param name="services"></param>
    private void UseSdkServices<TImplementation>(IServiceCollection services) where TImplementation : class, ISdkCredentialsService
    {
        services.AddTransient<ISdkCredentialsService, TImplementation>();
        services.AddTransient<IBidconAccess, BidconSdkAccess>();
    }
}
