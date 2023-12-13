using Microsoft.AspNetCore.Components;
using SharedLibraryWasmLibrary.Extensions;

namespace Server.Services;

public class StyleService
{
    private readonly NavigationManager _navigationManager;

    public StyleService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
    public string AppBarHeight { get; set; } = "50px";
    public string ActivePageStyle { get; set; } = "background-color: var(--mud-palette-action-disabled-background); color: var(--mud-palette-primary); min-width: 10px";
    public string CreateNavigationButtonStyle(string relativeButtonLink)
    {
        if (_navigationManager.IsIncludedInCurrentUri(relativeButtonLink))
        {
            return ActivePageStyle;
        }
        else
        {
            return "min-width: 10px";
        }
    }
    public string CreateActiveTabButtonStyle(bool tabIsActive)
    {
        if (tabIsActive)
        {
            return ActivePageStyle;
        }
        else
        {
            return "min-width: 10px";
        }
    }
}
