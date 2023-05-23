using Collie.Client.Extensions;
using Microsoft.AspNetCore.Components;

namespace Collie.Client.Shared.Helpers;

public class StyleService
{
    private readonly NavigationManager _navigationManager;

    public StyleService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
    public string AppBarHeight { get; set; } = "50px";
    public string CreateNavigationButtonStyle(string relativeButtonLink)
    {
        if (_navigationManager.IsIncludedInCurrentUri(relativeButtonLink))
        {
            return $"background-color: var(--mud-palette-action-disabled-background); color: var(--mud-palette-primary); min-width: 10px";
        }
        else
        {
            return "min-width: 10px";
        }
    }
}
