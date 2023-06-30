using Microsoft.JSInterop;

namespace SharedWasmLibrary.Shared.Services;
public class ScreenSizeService
{
    private readonly IJSRuntime _jSRuntime;
    private bool _isInitialized = false;

    public ScreenSizeService(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }
    public async Task Subscribe(Action<int> triggerAction)
    {
        await InitializeAsync();
        ScreenWidthChanged += triggerAction;
    }
    public void UnSubscribe(Action<int> triggerAction)
    {
        ScreenWidthChanged -= triggerAction;
    }
    private async Task InitializeAsync()
    {
        if (_isInitialized) return;

        _isInitialized = true;
        var dotnetRef = DotNetObjectReference.Create(this);
        await _jSRuntime.InvokeVoidAsync("window.resizeInterop.registerResizeCallback", dotnetRef, "OnWindowResize");
        CurrentScreenWidth = await GetWidnowWidth();
    }

    public int CurrentScreenWidth { get; set; }
    public event Action<int>? ScreenWidthChanged;
    [JSInvokable]
    public void OnWindowResize()
    {
        ScreenWidthChanged?.Invoke(CurrentScreenWidth);
        _ = Task.Run(async () => CurrentScreenWidth = await GetWidnowWidth());
    }
    private async Task<int> GetWidnowWidth()
    {
        return await _jSRuntime.InvokeAsync<int>("eval", "window.innerWidth");
    }
}
