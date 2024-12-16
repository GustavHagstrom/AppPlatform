using AppPlatform.Core.Constants;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using AppPlatform.ViewSettingsModule.Components;
using AppPlatform.ViewSettingsModule.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.ViewSettingsModule;
public class ViewSettingsModule : IModule
{
    public void RegisterAccessIds(AccessClaimInfoBuilder builder)
    {
        builder.AddAccessClaimInfo<ViewSettingsClaimInfo>();
    }
    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {
        componentBuilder.AddSettingsNavigationComponent<SettingsLink>();
    }

    public void GeneralConfig(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<Helper>();
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
        builder.Services.AddScoped<IViewService, ViewService>();
        builder.Services.AddScoped<IRoleViewService, RoleViewService>();
        builder.Services.AddScoped<IUserViewService, UserViewService>();
    }
    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }
    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {

    }
}
