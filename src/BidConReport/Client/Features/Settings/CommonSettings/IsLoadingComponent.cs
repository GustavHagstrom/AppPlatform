using Microsoft.AspNetCore.Components;

namespace BidConReport.Client.Features.Settings.CommonSettings;

public class IsLoadingComponent : ComponentBase
{
    [Parameter] 
    public EventCallback<bool> IsLoadingChanged { get; set; }
    public bool IsLoading { get; private set; } = true;
    public async Task SetLoading(bool isLoading)
    {
        IsLoading = isLoading;
        await IsLoadingChanged.InvokeAsync(isLoading);
        StateHasChanged();
    }
}
