using AppPlatform.Core.Constants;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using AppPlatform.UserRightSettingsModule.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppPlatform.UserRightSettingsModule.Data.Abstractions;
using AppPlatform.UserRightSettingsModule.Data.EfCore;
using Microsoft.Extensions.Hosting;
using AppPlatform.UserRightSettingsModule.Data.Mongo;

namespace AppPlatform.UserRightSettingsModule;
public class UserRightSettingsModule : IModule
{

    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {
        accessIdBuilder.AddAccessClaimInfo<ModuleAccessClaimInfo>();
    }
    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        componentBuilder.AddSettingsNavigationComponent<SettingsLink>();
    }
    public void GeneralConfig(WebApplicationBuilder builder)
    {
        
        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy(Constants.AuthorizationConstants.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                if (builder.Environment.IsProduction())
                {
                    policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.AuthorizationConstants.AccessClaimValue);
                }
            });
        });
        
    }
    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccessStore, SqlAccessStore>();
        builder.Services.AddScoped<IRoleStore, SqlRoleStore>();
    }
    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {
        builder.Services.AddScoped<IAccessStore, MongoAccessStore>();
        builder.Services.AddScoped<IRoleStore, MongoRoleStore>();
    }
    
}
