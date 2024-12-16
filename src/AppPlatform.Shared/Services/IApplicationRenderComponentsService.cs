using AppPlatform.Core.Abstractions;

namespace AppPlatform.Shared.Services;
public interface IApplicationRenderComponentsService
{
    IEnumerable<IInjectableComponent> CommonSettingsComponents { get; }
    IEnumerable<IInjectableComponent> SettingsNavigationComponents { get; }
    IEnumerable<IInjectableComponent> AppBarNavLinkComponents { get; }
}
