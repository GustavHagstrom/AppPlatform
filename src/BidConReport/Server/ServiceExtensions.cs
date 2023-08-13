using BidConReport.Server.Features.DarkMode;
using BidConReport.Server.Features.Import;
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
        services.UseDarkModeServices();
    }
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
    }
    public static void UseSharedServices(this IServiceCollection services)
    {
#if DEBUG
        services.AddTransient<IClaimsProvider, ClaimsProvider_debug>();
        services.AddSingleton<IOrganizationService, OrganizationService_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
        services.AddTransient<IOrganizationService, OrganizationService>();
#endif
    }
    public static void UseReportFeature(this IServiceCollection services)
    {
        services.AddTransient<IReportTemplatesCrudService, ReportTemplatesCrudService>();
    }
    public static void UseDarkModeServices(this IServiceCollection services)
    {
        services.AddTransient<IDarkModeService, DarkModeService>();
    }
}

