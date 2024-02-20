using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class LinkBuilder(IServiceCollection Services)
{
    private record LinkInfo(Type Service, Type Implementation, string Key);
    
    public void AddMainLayoutLink<T>() where T : class, IApplicationLink
    {
        Services.AddKeyedSingleton<IApplicationLink, T>(SharedApplicationLinkKeys.MainLayoutLink);

    }
    public void AddSettingsPageLink<T>() where T : class, IApplicationLink
    {
        Services.AddKeyedSingleton<IApplicationLink, T>(SharedApplicationLinkKeys.SettingsPageLink);
    }
    public void AddCustomLink<T>(string key) where T : class, IApplicationLink
    {
        Services.AddApplicationLink<T>(key);
    }
 
}
