using AppPlatform.BidconBrowserModule.Components;
using AppPlatform.Core.Constants;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppPlatform.BidconBrowserModule.Services;

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
        builder.Services.AddScoped<IBidconBrowserAccesService, BidconBrowserAccesService>();
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Authorization.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
    }

    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        
    }
    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {
        
    }
}
