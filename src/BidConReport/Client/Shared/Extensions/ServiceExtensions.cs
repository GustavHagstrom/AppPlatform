﻿using BidConReport.Client.Features.Import.Services;
using BidConReport.Client.Shared.BidconAccess.Services;
using BidConReport.Client.Shared.EstimationProcessing.Calculations;
using BidConReport.Client.Shared.EstimationProcessing.Services;
using BidConReport.Client.Shared.EstimationViewTemplate.Services;
using BidConReport.Client.Shared.Services;
using BidConReport.Client.Shared.StateContainers;

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
    public static void UseSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IReportTemplateService, ReportTemplateService>();
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
        services.AddTransient<IDarkModeService, DarkModeService>();
        services.AddTransient<IOrganizationService, OrganizationService>();

        services.AddTransient<IFolderService, FolderService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
        services.AddTransient<IEstimationViewTemplateServices, EstimationViewTemplateService>();
    }
    public static void UseDirectAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IDatabaseCredentialsService
    {
        services.AddTransient<IDatabaseCredentialsService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IConnectionstringService, ConnectionstringService>();
    }
}
