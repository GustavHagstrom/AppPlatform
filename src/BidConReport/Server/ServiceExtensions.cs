using BidConReport.Client.Features.Import.Services;
using BidConReport.Server.Features.Claims;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseClaimsFeature(this IServiceCollection services)
    {
#if DEBUG
        services.AddTransient<IClaimsProvider, ClaimsProvider_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
#endif
    }
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
    }
}

