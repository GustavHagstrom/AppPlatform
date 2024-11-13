using AppPlatform.Shared.Utilities;
using Microsoft.AspNetCore.Components;

namespace AppPlatform.Shared.Abstractions;
public interface IInjectableComponent
{
    RenderFragment Render()
    {
        return RenderEngine.Render(GetType());
    }
}
