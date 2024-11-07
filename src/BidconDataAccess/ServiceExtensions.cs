using AppPlatform.BidconDatabaseAccess.Services.DbAccess;
using AppPlatform.BidconDatabaseAccess.Services.SdkAccess;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.BidconDatabaseAccess;

public static class ServiceExtensions
{
    /// <summary>
    /// Use this when using direct access to DB
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <param name="services"></param>
    public static void UseBidconDbAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IBidconDbConnectionstringService
    {
        services.AddTransient<IBidconDbConnectionstringService, TImplementation>();
        services.AddTransient<IEstimationQueryService, EstimationQueryService>();
    }
    /// <summary>
    /// Use this when using SDK access to DB
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <param name="services"></param>
    public static void UseBidconSdkAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, ISdkCredentialsService
    {
        services.AddTransient<ISdkCredentialsService, TImplementation>();

    }
}
