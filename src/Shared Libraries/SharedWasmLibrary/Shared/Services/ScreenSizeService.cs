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
        
        await _jSRuntime.InvokeVoidAsync("eval", @"
        (function() {
            var script = document.createElement('script');
            script.innerHTML = '(function() { window.resizeInterop = { registerResizeCallback: function(dotNetReference, methodName) { window.addEventListener(\'resize\', function() { dotNetReference.invokeMethodAsync(methodName); }); } }; })();';
            document.body.appendChild(script);
        })();
    ");
        var dotnetRef = DotNetObjectReference.Create(this);
        await _jSRuntime.InvokeVoidAsync("window.resizeInterop.registerResizeCallback", dotnetRef, "OnWindowResize");
        CurrentScreenWidth = await GetWidnowWidth();
    }

    public int CurrentScreenWidth { get; set; }
    private event Action<int>? ScreenWidthChanged;
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
