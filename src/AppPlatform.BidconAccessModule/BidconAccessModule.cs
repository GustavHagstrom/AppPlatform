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
        componentBuilder.AddSettingsComponent<BidconSdkAccessData>();
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.UseBidconDirectDbAccess<BidconDatabaseConnectionsStringService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
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
