using BidConReport.Server.Services.Authentication;
using BidConReport.Server.Services.Settings;

namespace BidConReport.Server;

internal static class ServiceExtensions
{
    public static void UseAllServices(this IServiceCollection services)
    {
        services.AddTransient<IDarkModeService, DarkModeService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

#if DEBUG
        services.AddTransient<IClaimsService, ClaimsService_debug>();
#else
        services.AddTransient<IClaimsProvider, ClaimsProvider>();
        services.AddTransient<IOrganizationService, OrganizationService>();
#endif
    }
}

