using AppPlatform.Shared.Abstractions;

namespace AppPlatform.Shared.Services;
public interface IApplicationRenderComponentsService
{
    IEnumerable<IInjectableComponent> CommonSettingsComponents { get; }
}
