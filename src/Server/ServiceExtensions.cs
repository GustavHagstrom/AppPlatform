using MudBlazor;
using MudBlazor.Services;
using AppPlatform.Server.Components.Features.Settings.OrganizationSettings;
using AppPlatform.Core.Services;
using AppPlatform.Core.Services.Email;
using AppPlatform.Core.Services.Settings;


namespace AppPlatform.Server;

internal static class ServiceExtensions
{
    public static void RegisterApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization();
        builder.Services.AddScoped<IDarkModeService, DarkModeService>();
        builder.Services.AddTransient<IOrganizationService, OrganizationService>();
        builder.Services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        builder.Services.AddTransient<OrganizationValidation>();
        builder.Services.AddTransient<SubscriptionService>();
        builder.Services.AddTransient<UserListService>();
        builder.Services.AddTransient<IInvitationService, InvitationService>();
        builder.Services.AddSingleton<IEmailService, EmailService>();
        builder.Services.AddMudServices(config =>
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

