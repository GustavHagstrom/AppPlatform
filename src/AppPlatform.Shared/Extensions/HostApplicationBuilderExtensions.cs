using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Builders;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Services;
using AppPlatform.Shared.Services.Authorization;
using AppPlatform.Shared.Services.Email;
using AppPlatform.Shared.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Extensions;
public static class HostApplicationBuilderExtensions
{

    public static void AddModules(this IServiceCollection services, Action<ModuleBuilder> configure)
    {
        var moduleBuilder = new ModuleBuilder(services);
        configure(moduleBuilder);
        moduleBuilder.Build();
    }
    public static void AddApplicationLinks(this IServiceCollection services, Action<LinkBuilder> configure)
    {
        var applicationLinkBuilder = new LinkBuilder(services);
        configure(applicationLinkBuilder);
    }
    public static void AddShared(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddScoped<IDarkModeService, DarkModeService>();
        services.AddTransient<IBidconCredentialsService, BidconCredentialsService>();
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<ILocalStorageService, LocalStorageService>();
        services.AddTransient<IAccessClaimService, AccessClaimService>();
        services.AddSingleton<IApplicationLinkService, ApplicationLinkService>();
        services.AddKeyedSingleton<IApplicationLink, SettingsMainNavLink>(SharedApplicationLinkKeys.MainLayoutLink);
    }
}
