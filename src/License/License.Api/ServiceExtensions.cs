using License.Api.Features.Claims;
using License.Api.Features.Seed;

namespace License.Api;
internal static class ServiceExtensions
{
    public static void UseSeedFeature(this IServiceCollection services)
    {
        services.AddTransient<ISeedService, SeedService>();
    }
    public static void UseClaimsFeature(this IServiceCollection services)
    {
        services.AddTransient<IClaimService, ClaimService>();
    }
}
