using Microsoft.Extensions.DependencyInjection;
using SharedPlatformLibrary.Wrappers;

namespace SharedPlatformLibrary;
public static class ServiceExtensions
{
    public static void UseSharedPlatformLibrary(this IServiceCollection services)
    {
        services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
    }
}
