using BidConReport.Server.Features.Claims;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseClaimsFeature(this IServiceCollection services)
    {
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
    }
}
