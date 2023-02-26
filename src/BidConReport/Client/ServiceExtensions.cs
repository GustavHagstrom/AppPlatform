using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Logic;

namespace BidConReport.Client;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporter, BidConImporter>();
        services.AddTransient<IEstimationImportSettingsState, EstimationImportSettingsState>();
    }
    public static void UseAuthenticationFeature(this IServiceCollection services)
    {

    }
}
