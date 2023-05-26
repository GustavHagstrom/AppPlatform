using Microsoft.Extensions.DependencyInjection;
using SharedWebLibrary.Services;

namespace SharedWebLibrary;
public static class ServiceExtensions
{
    public static void UseSharedWebLibrary(this IServiceCollection services)
    {
        services.AddTransient<StyleService>();
    }
}
