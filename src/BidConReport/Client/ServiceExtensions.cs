using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Services;

namespace BidConReport.Client;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporterService, BidConImporterService>();
        services.AddTransient<IImportSettingsService, ImportSettingsService>();

    }
    public static void UseAuthenticationFeature(this IServiceCollection services)
    {

    }
}
