using BidConReport.DirectAccess.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BidConReport.DirectAccess.Extensions;
public static class ServiceExtensions
{
    public static void UseDirectAccess<TImplementation>(this IServiceCollection services) where TImplementation : class, IConnectionstringProvider
    {
        services.AddTransient<IConnectionstringProvider, TImplementation>();
        services.AddTransient<ISqlEngine, DapperEngine>();
    }
}
