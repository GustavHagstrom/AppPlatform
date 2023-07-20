﻿using BidConReport.Server.Features.Import;
using BidConReport.Server.Features.Report;
using BidConReport.Server.Shared.Services;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseAllServices(this IServiceCollection services)
    {
        services.UseImportFeature();
        services.UseSharedServices();
        services.UseReportFeature();
    }
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
    public static void UseReportFeature(this IServiceCollection services)
    {
        services.AddTransient<IReportTemplatesCrudService, ReportTemplatesCrudService>();
    }
}

