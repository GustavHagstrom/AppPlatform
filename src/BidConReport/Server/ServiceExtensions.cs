using BidConReport.Server.Features.Import;
using BidConReport.Server.Shared.Services;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseAllServices(this IServiceCollection services)
    {
        //services.UseClaimsFeature();
        services.UseImportFeature();
        services.UseSharedServices();
    }
    //public static void UseClaimsFeature(this IServiceCollection services)
    //{

    //}
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
    }
    public static void UseSharedServices(this IServiceCollection services)
    {
#if DEBUG
        services.AddTransient<IClaimsProvider, ClaimsProvider_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
#endif
    }
}

