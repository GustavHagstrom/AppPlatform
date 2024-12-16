using AppPlatform.Core.Constants;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using AppPlatform.UserRightSettingsModule.Components;
using AppPlatform.UserRightSettingsModule.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, Constants.AuthorizationConstants.AccessClaimValue);
            });
        });
    }
    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccessService, AccessService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
    }
    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {

    }
    
}
