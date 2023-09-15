using Server.Services.Authentication;
using Server.Services.EstimationView;
using Server.Services.Settings;

namespace Server;

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

