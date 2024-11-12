using Microsoft.AspNetCore.Components;

namespace AppPlatform.Shared.Abstractions;
public interface IInjectableComponent
{
    RenderFragment Render();
}
