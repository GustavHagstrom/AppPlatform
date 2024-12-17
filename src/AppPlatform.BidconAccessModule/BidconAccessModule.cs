using AppPlatform.BidconAccessModule.SdkAccess.Services;
using AppPlatform.Core.Constants;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppPlatform.BidconAccessModule.DirectAccess.Data.EfCore;
using AppPlatform.BidconAccessModule.DirectAccess.Data.Abstractions;
using AppPlatform.BidconAccessModule.DirectAccess.Data.Mongo;

namespace AppPlatform.BidconAccessModule;
public class BidconAccessModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleClaimInfo>();
    }

    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {

    }

    public void GeneralConfig(WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IBidconAccess, BidconSdkReflectionAccess>();
        builder.Services.AddScoped<IBidconReflectionService, BidconReflectionService>();

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Constants.Authorization.EditBidconConnectionPolicy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.Authorization.AccessClaimValue);
            });
    }
    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDirectCredentialsStore, SqlDirectCredentialsStore>();
    }

    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {
        builder.Services.AddTransient<IDirectCredentialsStore, MongoDirectCredentialsStore>();
    }


    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
}
