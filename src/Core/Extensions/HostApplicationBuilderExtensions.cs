using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Core.Extensions;
public static class HostApplicationBuilderExtensions
{

    public static void AddModules(this WebApplicationBuilder builder, Action<ModuleBuilder> configure)
    {
        var moduleBuilder = new ModuleBuilder(builder);
        configure(moduleBuilder);
    }
    public static void AddApplicationInjectableComponent<T>(this IServiceCollection services, string key) where T : class, IInjectableComponent
    {
        services.AddKeyedTransient<IInjectableComponent, T>(key);
    }
    public static void AddAccessClaimInfo<T>(this IServiceCollection services) where T : class, IAccessClaimInfo
    {
        services.AddSingleton<IAccessClaimInfo, T>();
    }
}
