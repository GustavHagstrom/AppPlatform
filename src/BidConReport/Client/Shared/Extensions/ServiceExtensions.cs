using BidConReport.Client.Features.Authentication;
using BidConReport.Client.Features.Import.Services;
using BidConReport.Client.Features.Settings.BidconSettings.BicdonCredentials;
using BidConReport.Client.Shared.EstimationProcessing.Calculations;
using BidConReport.Client.Shared.EstimationProcessing.Services;
using BidConReport.Client.Shared.EstimationViewTemplate.Services;
using BidConReport.Client.Shared.Services;
using BidConReport.Shared.Wrappers;
using Microsoft.AspNetCore.Components.Authorization;

namespace BidConReport.Client.Shared.Extensions;

public static class ServiceExtensions
{
    public static void UseSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();

        services.AddTransient<IDarkModeService, DarkModeService>();

        services.AddTransient<IFolderService, FolderService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
        services.AddTransient<IEstimationViewTemplateServices, EstimationViewTemplateService>();

        services.AddTransient<IBidconLinkService, BidconLinkService>();
        services.AddTransient<IConfigReaderService, ConfigReaderService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

        services.AddScoped<IEstimationContainerService, EstimationContainerService>();

        services.AddTransient<StyleService>();
        services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        services.AddScoped<ScreenSizeService>();
    }
}
