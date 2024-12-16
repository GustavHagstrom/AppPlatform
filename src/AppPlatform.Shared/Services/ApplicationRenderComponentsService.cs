using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Services;
public class ApplicationRenderComponentsService : IApplicationRenderComponentsService
{
    private readonly IServiceProvider serviceProvider;

    public ApplicationRenderComponentsService(IServiceProvider sp)
    {
        serviceProvider = sp;
    }
    public IEnumerable<IInjectableComponent> CommonSettingsComponents => serviceProvider.GetKeyedServices<IInjectableComponent>(SharedInjectableComponentKeys.CommonSettingsComponent);

    public IEnumerable<IInjectableComponent> SettingsNavigationComponents => serviceProvider.GetKeyedServices<IInjectableComponent>(SharedInjectableComponentKeys.SettingsNavigationComponent);
    public IEnumerable<IInjectableComponent> AppBarNavLinkComponents => serviceProvider.GetKeyedServices<IInjectableComponent>(SharedInjectableComponentKeys.AppBarNavLinkComponent);
}
