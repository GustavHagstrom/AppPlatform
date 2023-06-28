using Microsoft.JSInterop;

namespace SharedWasmLibrary.Shared.Services;
public class ScreenSizeService
{
    private readonly IJSRuntime _jSRuntime;
    private bool _isInitialized;

    public ScreenSizeService(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }
    public async Task InitializeAsync()
    {
        if (_isInitialized) return;

        _isInitialized = true;
        var dotnetRef = DotNetObjectReference.Create(this);
        await _jSRuntime.InvokeVoidAsync("addEventListener", "resize", dotnetRef, "OnBrowserResize");
        CurrentScreenWidth = await GetWidnowWidth();
    }

    public int CurrentScreenWidth { get; set; }
    public event EventHandler<int>? ScreenWidthChanged;
    [JSInvokable]
    private void OnWindowResize()
    {
        CurrentScreenWidth = GetWidnowWidth().Result;
        ScreenWidthChanged?.Invoke(this, CurrentScreenWidth);
    }
    private async Task<int> GetWidnowWidth()
    {
        return await _jSRuntime.InvokeAsync<int>("eval", "window.innerWidth");
    }
}
