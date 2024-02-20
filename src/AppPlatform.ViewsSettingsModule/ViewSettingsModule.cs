using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.ViewSettingsModule;
public class ViewSettingsModule : IModule
{
    public void RegisterAccessIds(AccessIdBuilder builder)
    {
        builder.AddAccessId(AuthorizationConstants.AccessClaimValue);
    }

    public void RegisterApplicationLinks(LinkBuilder builder)
    {
        builder.AddSettingsPageLink<SettingsLink>();
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddAuthorization(configure =>
        {
            configure.AddPolicy(AuthorizationConstants.Policy, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, AuthorizationConstants.AccessClaimValue);
            });
        });
    }
}
