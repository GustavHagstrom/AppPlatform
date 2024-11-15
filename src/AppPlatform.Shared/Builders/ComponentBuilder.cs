using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ComponentBuilder(IServiceCollection Services)
{
    /// <summary>
    /// Components to be rendered in the Common settings page
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void AddCommonSettingsComponent<T>() where T : class, IInjectableComponent
    {
        Services.AddApplicationInjectableComponent<T>(SharedInjectableComponentKeys.CommonSettingsComponent);
    }
    /// <summary>
    /// Components to be rendered in the Settings navigation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void AddSettingsNavigationComponent<T>() where T : class, IInjectableComponent
    {
        Services.AddApplicationInjectableComponent<T>(SharedInjectableComponentKeys.SettingsNavigationComponent);
    }
    /// <summary>
    /// Components to be rendered in the AppBar
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void AddAppBarNavLinkComponent<T>() where T : class, IInjectableComponent
    {
        Services.AddApplicationInjectableComponent<T>(SharedInjectableComponentKeys.AppBarNavLinkComponent);
    }
}
