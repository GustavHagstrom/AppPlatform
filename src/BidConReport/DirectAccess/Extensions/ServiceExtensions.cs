using BidConReport.BidconAccess.Services;
using BidConReport.BidconAccess.Services.BidconAccess;
using BidConReport.BidconAccess.Services.EstimationBuilding;
using Microsoft.Extensions.DependencyInjection;

namespace BidConReport.BidconAccess.Extensions;
public static class ServiceExtensions
{
    public static void UseDirectAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IDatabaseCredentialsService
    {
        services.AddTransient<IDatabaseCredentialsService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        services.AddTransient<IDbFolderService, DbFolderService>();
        //services.AddTransient<IDirectEstimationService, DirectEstimationService>();
        services.AddTransient<IConnectionstringService, ConnectionstringService>();
        services.AddTransient<ILayerdItemCalculator, LayerdItemCalculator>();
        services.AddTransient<IEstimationBuilder, EstimationBuilder>();
    }
}
