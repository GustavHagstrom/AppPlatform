using Microsoft.Extensions.DependencyInjection;

namespace BidconDataAccess;

public static class ServiceExtensions
{
    public static void UseBidconDataAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IConnectionstringService
    {
        services.AddTransient<IConnectionstringService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
    }
}
