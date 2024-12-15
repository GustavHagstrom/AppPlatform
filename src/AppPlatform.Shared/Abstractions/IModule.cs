using AppPlatform.Shared.Builders;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace AppPlatform.Shared.Abstractions;
public interface IModule
{
    void GeneralConfig(WebApplicationBuilder builder);
    void ConfigForEfCore(WebApplicationBuilder builder);
    void OnEfCoreModelCreating(ModelBuilder modelBuilder);
    void ConfigForMongoDb(WebApplicationBuilder builder);
    void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder);
    void RegisterInjectableComponents(ComponentBuilder componentBuilder);
}
