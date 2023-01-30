using ApiAccessLibrary.ApiHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAccessLibrary.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddApiAccessLibrary(this IServiceCollection services, HttpClient httpClientInstance)
    {
        services.AddTransient<IAuthenticationApiHandler, AuthenticationApiHandler>();
        services.AddTransient<IBidconApiHandler, BidconApiHandler>();
        services.AddSingleton(httpClientInstance);
        return services;
    }
}
