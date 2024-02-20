using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class LinkBuilder(IServiceCollection Services)
{
    private record LinkInfo(Type Service, Type Implementation, string Key);
    
    public void AddMainLayoutLink<TLink>() where TLink : class, IApplicationLink
    {
        Services.AddKeyedSingleton<IApplicationLink, TLink>(SharedApplicationLinkKeys.MainLayoutLink);

    }
    public void AddSettingsPageLink<TLink>() where TLink : class, IApplicationLink
    {
        Services.AddKeyedSingleton<IApplicationLink, TLink>(SharedApplicationLinkKeys.SettingsPageLink);
    }
    public void AddCustomLink<TLink>(string key) where TLink : class, IApplicationLink
    {
        Services.AddKeyedSingleton<IApplicationLink, TLink>(key);
    }
 
}
