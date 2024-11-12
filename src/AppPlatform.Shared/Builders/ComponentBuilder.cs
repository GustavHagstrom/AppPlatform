using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ComponentBuilder(IServiceCollection Services)
{
    public void AddSettingsComponent<T>() where T : class, IInjectableComponent
    {
        Services.AddApplicationInjectableComponent<T>(SharedInjectableComponentKeys.CommonSettingsComponent);
    }
}
