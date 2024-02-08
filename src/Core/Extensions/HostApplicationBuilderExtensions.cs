using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Services;
using AppPlatform.Core.Services.Email;
using AppPlatform.Core.Services.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppPlatform.Core.Extensions;
public static class HostApplicationBuilderExtensions
{
    public static void AddModule<TModule>(this IHostApplicationBuilder builder) where TModule : ModuleBase, new()
    {
        var module = new TModule();
        module.AddModule(builder);
    }
    public static void AddCore(this IHostApplicationBuilder builder)
    {
        builder.Services.AddLocalization();
        builder.Services.AddScoped<IDarkModeService, DarkModeService>();
        builder.Services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        builder.Services.AddSingleton<IEmailService, EmailService>();
        builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
    }
}
