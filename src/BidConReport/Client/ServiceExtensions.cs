using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Services;
using BidConReport.Client.Shared.Services;
using BidConReport.Client.Shared.StateContainers;
using Microsoft.AspNetCore.Components.Authorization;

namespace BidConReport.Client;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporterService, BidConImporterService>();
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
    }
    public static void UseSharedStateContainers(this IServiceCollection services)
    {
        services.AddScoped<ImportedEstimationsContainer>();
    }
    public static void UserSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IEstimationParentReferencer, EstimationParentReferencer>();
        services.AddTransient<IEstimationItemTraverser, EstimationItemTraverser>();
    }
}
