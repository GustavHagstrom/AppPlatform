using BidConReport.BidconDatabaseAccess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BidConReport.BidconDatabaseAccess.Extensions;
public static class ServiceExtensions
{
    public static void UseDirectAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IDatabaseCredentialsService
    {
        services.AddTransient<IDatabaseCredentialsService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IDbFolderService, DbFolderService>();
        services.AddTransient<IDirectEstimationService, DirectEstimationService>();
        services.AddTransient<IConnectionstringService, ConnectionstringService>();
    }
}
