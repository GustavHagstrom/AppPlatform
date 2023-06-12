using License.Api.Features.Claims;
using License.Api.Features.AppSeed;

namespace License.Api;
internal static class ServiceExtensions
{
    public static void UseSeedFeature(this IServiceCollection services)
    {
        services.AddTransient<IAppSeedService, AppSeedService>();
    }
    public static void UseClaimsFeature(this IServiceCollection services)
    {
        services.AddTransient<IClaimService, ClaimService>();
    }
}
