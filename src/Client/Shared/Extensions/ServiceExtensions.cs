using Client.Features.Authentication;
using Client.Features.Import.Services;
using Client.Shared.EstimationProcessing.Calculations;
using Client.Shared.EstimationProcessing.Services;
using Client.Shared.EstimationViewTemplate.Services;
using Client.Shared.Services;
using SharedLibrary.Wrappers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.Shared.Extensions;

public static class ServiceExtensions
{
    public static void UseSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IBidconBackendAccessService, BidconBackendAccessService>();
        services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();

        services.AddTransient<IDarkModeService, DarkModeService>();

        services.AddTransient<IFolderService, FolderService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
        services.AddTransient<IEstimationViewTemplateServices, EstimationViewTemplateService>();

        services.AddTransient<IBidconLinkService, BidconLinkService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

        services.AddScoped<IEstimationContainerService, EstimationContainerService>();

        services.AddTransient<StyleService>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddScoped<ScreenSizeService>();
    }
}
