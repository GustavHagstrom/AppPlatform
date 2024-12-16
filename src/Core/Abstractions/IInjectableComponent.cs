using AppPlatform.Core.Utilities;
using Microsoft.AspNetCore.Components;

namespace AppPlatform.Core.Abstractions;
public interface IInjectableComponent
{
    RenderFragment Render()
    {
        return RenderEngine.Render(GetType());
    }
}
