using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Services;
using BidConReport.Client.Shared.Services;
using BidConReport.Client.Shared.Services.EstimationBuilding;
using BidConReport.Client.Shared.StateContainers;
using Microsoft.AspNetCore.Components.Authorization;

namespace BidConReport.Client.Shared.Extensions;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporterService, BidConImporterService>();
        
    }
    public static void UseSharedStateContainers(this IServiceCollection services)
    {
        services.AddScoped<ImportedEstimationsContainer>();
    }
    public static void UserSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IReportTemplateService, ReportTemplateService>();
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
        services.AddTransient<IDarkModeService, DarkModeService>();
        services.AddTransient<IOrganizationService, OrganizationService>();

        services.AddTransient<IFolderService, FolderService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
    }
}
