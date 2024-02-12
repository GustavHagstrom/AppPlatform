using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Services.Email;
using AppPlatform.Core.Services.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppPlatform.Core.Extensions;
public static class HostApplicationBuilderExtensions
{
    public static void AddModule<TModule>(this IServiceCollection services) where TModule : ModuleBase, new()
    {
        var module = new TModule();
        module.AddModule(services);
    }
    public static void AddCore(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
    }
}
