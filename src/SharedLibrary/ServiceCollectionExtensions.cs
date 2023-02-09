using Microsoft.Extensions.DependencyInjection;

namespace SharedLibrary;
public static class ServiceCollectionExtensions
{
    public static void UseSharedLibraryServices(this IServiceCollection services)
    {
        services.AddHttpClient("Middleware", client => client.BaseAddress = new Uri("https://graph.microsoft.com/v1.0"));
    }
}
