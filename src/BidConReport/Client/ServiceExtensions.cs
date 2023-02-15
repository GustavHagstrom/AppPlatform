using BidConReport.Client.Features.Import.Logic;

namespace BidConReport.Client;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporter, BidConImporter>();
        services.AddTransient<IEstimationImportSettingsState, EstimationImportSettingsState>();
        services.AddTransient<IEstimationImportState, EstimationImportState>();
    }
}
