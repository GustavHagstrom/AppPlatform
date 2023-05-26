using Microsoft.AspNetCore.Components;

namespace SharedWebLibrary.Extensions;

public static class NavigationManagerExtensions
{
    public static bool IsIncludedInCurrentUri(this NavigationManager navManager, string url)
    {
        if (url.FirstOrDefault() == '/')
        {
            url = url[1..];
        }
        var path = navManager.Uri.Replace(navManager.BaseUri, string.Empty).ToLower();
        return path.StartsWith(url.ToLower());
    }
}
