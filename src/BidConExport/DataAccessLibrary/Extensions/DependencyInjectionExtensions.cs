using Dapper;
using DataAccessLibrary.Abstractions;
using DataAccessLibrary.Engines;
using DataAccessLibrary.Helpers;
using DataAccessLibrary.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLibrary.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDataAccessLibrary(this IServiceCollection services)
    {
        services.AddSingleton<IMongoEngine, MongoEngine>();
        services.AddTransient<IUserStore, UserStore>();
        services.AddTransient<IRoleStore, RoleStore>();
        services.AddTransient<IUserRoleStore, UserRoleStore>();
        services.AddTransient<ISqlEngine, DapperEngine>();
        services.AddTransient<IEstimationImportSettingsStore, EstimationImportSettingsStore>();

        SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
        SqlMapper.RemoveTypeMap(typeof(Guid));
        SqlMapper.RemoveTypeMap(typeof(Guid?));

        return services;
    }
}
