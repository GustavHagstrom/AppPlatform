using AppPlatform.BidconBrowserModule.Components;
using AppPlatform.BidconBrowserModule.Services;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.BidconBrowserModule;
public class BidconBrowserModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleClaimInfo>();
    }
    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        componentBuilder.AddAppBarNavLinkComponent<BidconBrowserAppLink>();
    }
    public void GeneralConfig(WebApplicationBuilder builder)
    {
        
        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy(Constants.Authorization.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
        });
    }

    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBidconBrowserAccesService, BidconBrowserAccesService>();
    }
    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionBuilder collectionBuilder)
    {

    }
}
