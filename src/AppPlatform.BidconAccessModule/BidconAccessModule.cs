using AppPlatform.BidconAccessModule.Components;
using AppPlatform.BidconAccessModule.Services;
using AppPlatform.BidconDatabaseAccess;
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
        services.UseBidconDirectDbAccess<BidconDatabaseConnectionsStringService>();



        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Authorization.EditBidconConnectionPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
    }
}
