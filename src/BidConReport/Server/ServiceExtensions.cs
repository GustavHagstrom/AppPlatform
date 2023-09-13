using BidConReport.Server.Services.Authentication;
using BidConReport.Server.Services.EstimationView;
using BidConReport.Server.Services.Settings;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseAllServices(this IServiceCollection services)
    {
        services.AddTransient<IEstimationViewTemplateService, EstimationViewTemplateService>();
        services.AddTransient<IEstimationViewTemplateUpdater, EstimationViewTemplateUpdater>();
        services.AddTransient<IDarkModeService, DarkModeService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

#if DEBUG
        services.AddTransient<IClaimsService, ClaimsService_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
#endif
    }
}

