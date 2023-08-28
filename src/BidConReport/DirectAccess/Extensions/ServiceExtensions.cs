using BidConReport.BidconAccess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BidConReport.BidconAccess.Extensions;
public static class ServiceExtensions
{
    public static void UseDirectAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IDatabaseCredentialsService
    {
        services.AddTransient<IDatabaseCredentialsService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IConnectionstringService, ConnectionstringService>();
    }
}
