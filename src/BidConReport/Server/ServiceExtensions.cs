using BidConReport.Server.Services.Authentication;
using BidConReport.Server.Services.Import;
using BidConReport.Server.Services.Report;
using BidConReport.Server.Services.Settings;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseAllServices(this IServiceCollection services)
    {
        services.AddTransient<IImportSettingsService, ImportSettingsService>();
        services.AddTransient<IReportTemplatesService, ReportTemplatesService>();
        services.AddTransient<IDarkModeService, DarkModeService>();

#if DEBUG
        services.AddTransient<IClaimsService, ClaimsService_debug>();
        services.AddSingleton<IOrganizationService, OrganizationService_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
        services.AddTransient<IOrganizationService, OrganizationService>();
#endif
    }
}

