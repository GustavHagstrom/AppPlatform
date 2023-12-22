using MudBlazor;
using MudBlazor.Services;
using Server.Components.Features.Settings.OrganizationSettings;
using Server.Services.Settings;


namespace Server;

internal static class ServiceExtensions
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddTransient<IOrganizationService, OrganizationService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 1000 * 5;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

        });
        //services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();

        //services.AddTransient<IDarkModeService, DarkModeService>();

        //services.AddTransient<IFolderService, FolderService>();
        //services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        //services.AddTransient<IEstimationBuilderService, EstimationBuilderService>();
        //services.AddTransient<IEstimationViewTemplateServices, EstimationViewTemplateService>();

        //services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

        //services.AddScoped<IEstimationContainerService, EstimationContainerService>();

        //services.AddTransient<StyleService>();
        //services.AddScoped<ScreenSizeService>();
    }
}

