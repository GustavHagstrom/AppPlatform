using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AppPlatform.Shared.Builders;
public class ApplicationLinkBuilder(IServiceCollection Services)
{
    private record LinkInfo(Type Service, Type Implementation, string Key);
    private HashSet<LinkInfo> links = new();
    
    public void AddMainLayoutLink<TLink>() where TLink : IApplicationLink
    {
        links.Add(new LinkInfo(typeof(IApplicationLink), typeof(TLink), SharedApplicationLinkKeys.MainLayoutLink));

    }
    public void AddCustomLink<TLink>(string key) where TLink : IApplicationLink
    {
        links.Add(new LinkInfo(typeof(IApplicationLink), typeof(TLink), key));
    }
    public void Build()
    {
        foreach (var link in links)
        {
            Services.AddKeyedSingleton(link.Service, link.Implementation, link.Key);
        }
    }
}
