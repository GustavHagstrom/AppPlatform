using DataAccessLibrary.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLibrary.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDataAccessLibrary(this IServiceCollection services)
    {
        services.AddTransient<IEstimationImportSettingsStore, EstimationImportSettingsStore>();

        return services;
    }
}
