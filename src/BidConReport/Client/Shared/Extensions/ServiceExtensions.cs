using BidConReport.Client.Features.Import.Services;
using BidConReport.Client.Features.Settings.BidconSettings.BicdonCredentials;
using BidConReport.Client.Shared.EstimationProcessing.Calculations;
using BidConReport.Client.Shared.EstimationProcessing.Services;
using BidConReport.Client.Shared.EstimationViewTemplate.Services;
using BidConReport.Client.Shared.Services;

namespace BidConReport.Client.Shared.Extensions;

public static class ServiceExtensions
{
    public static void UseSharedServices(this IServiceCollection services)
    {
        services.AddTransient<IDarkModeService, DarkModeService>();
        services.AddTransient<IOrganizationService, OrganizationService>();

        services.AddTransient<IFolderService, FolderService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
        services.AddTransient<IEstimationViewTemplateServices, EstimationViewTemplateService>();

        services.AddTransient<IBidconLinkService, BidconLinkService>();
        services.AddTransient<IConfigReaderService, ConfigReaderService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

        services.AddScoped<IEstimationContainerService, EstimationContainerService>();
    }
}
