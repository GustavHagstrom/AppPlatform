using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Services;
using AppPlatform.Shared.Services.Email;
using AppPlatform.Shared.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Extensions;
public static class HostApplicationBuilderExtensions
{
    public static void AddModule<TModule>(this IServiceCollection services) where TModule : ModuleBase, new()
    {
        var module = new TModule();
        module.AddModule(services);
    }
    public static void AddShared(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
    }
}
