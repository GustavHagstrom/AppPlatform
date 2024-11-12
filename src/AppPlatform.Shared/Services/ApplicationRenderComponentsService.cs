using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Services;
public class ApplicationRenderComponentsService : IApplicationRenderComponentsService
{
    public ApplicationRenderComponentsService(
        [FromKeyedServices(SharedInjectableComponentKeys.CommonSettingsComponent)] IEnumerable<IInjectableComponent> CommonSettingsComponents)
    {
        this.CommonSettingsComponents = CommonSettingsComponents;
    }
    public IEnumerable<IInjectableComponent> CommonSettingsComponents { get; }
}
