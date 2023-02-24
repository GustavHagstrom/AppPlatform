using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Logic;
using Microsoft.AspNetCore.Components.Authorization;

namespace BidConReport.Client;

public static class ServiceExtensions
{
    public static void UseImportFeature(this IServiceCollection services)
    {
        services.AddTransient<IBidConImporter, BidConImporter>();
        services.AddTransient<IEstimationImportSettingsState, EstimationImportSettingsState>();
        services.AddTransient<IEstimationImportState, EstimationImportState>();
    }
    public static void UseAuthenticationFeature(this IServiceCollection services)
    {
        services.AddScoped<OnLoginScopedData>();
        //services.AddScoped<AuthenticationStateProvider, MsGraphAuthenticationStateProvider>();
    }
}
