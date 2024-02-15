using AppPlatform.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared;
public static class ServiceExtensions
{
    public static void AddShared(this IServiceCollection services)
    {
        services.AddScoped<ILocalStorageService, LocalStorageService>();
    }
}
