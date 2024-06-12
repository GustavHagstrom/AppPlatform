using AppPlatform.BidconBrowserModule.Services;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.BidconBrowserModule;
public class BidconBrowserModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleClaimInfo>();
    }

    public void RegisterApplicationLinks(LinkBuilder applicationLinkBuilder)
    {
        applicationLinkBuilder.AddMainLayoutLink<BidconBrowserAppLink>();
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IBidconBrowserAccesService, BidconBrowserAccesService>();
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
