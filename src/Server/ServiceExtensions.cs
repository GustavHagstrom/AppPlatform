using MudBlazor;
using MudBlazor.Services;
using Server.Services;
using Server.Services.Authentication;
using Server.Services.EstimationView;
using Server.Services.Settings;

namespace Server;

internal static class ServiceExtensions
{
//    public static void UseAllServices(this IServiceCollection services)
//    {
//        services.AddTransient<IEstimationViewTemplateService, EstimationViewTemplateService>();
//        services.AddTransient<IEstimationViewTemplateUpdater, EstimationViewTemplateUpdater>();
//        services.AddTransient<IDarkModeService, DarkModeService>();
//        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();

//#if DEBUG
//        services.AddTransient<IClaimsService, ClaimsService_debug>();
//#else
//        services.AddTransient<IClaimsProvider, ClaimsProvider>();
//#endif
//    }
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddTransient<StyleService>();
        services.AddScoped<Services.Settings.IDarkModeService, Services.Settings.DarkModeService>();
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

