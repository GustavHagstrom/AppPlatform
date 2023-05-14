using Microsoft.AspNetCore.Components;

namespace Collie.Client.Extensions;

public static class NavigationManagerExtensions
{
    public static bool IsIncludedInCurrentUri(this NavigationManager navManager, string url)
    {
        if (url.FirstOrDefault() == '/')
        {
            url = url[1..];
        }
        var path = navManager.Uri.Replace(navManager.BaseUri, string.Empty);
        return path.StartsWith(url);
    }
}
