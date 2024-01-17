using Microsoft.JSInterop;

namespace AppPlatform.Server.Services;
public class ScreenSizeService
{
    private readonly IJSRuntime _jSRuntime;
    private bool _isInitialized = false;

    public ScreenSizeService(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }
    public async Task Subscribe(Action triggerAction)
    {
        await InitializeAsync();
        ScreenWidthChanged += triggerAction;
    }
    public void UnSubscribe(Action triggerAction)
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
        await _jSRuntime.InvokeVoidAsync("window.resizeInterop.registerResizeCallback", dotnetRef, nameof(OnWindowResize));
        CurrentScreenWidth = await GetWindowWidth();
        LastScreenWidth = CurrentScreenWidth;
    }
    public int LastScreenWidth { get; private set; }
    public int CurrentScreenWidth { get; private set; }
    private event Action? ScreenWidthChanged;
    [JSInvokable]
    public void OnWindowResize()
    {
        GetWindowWidth().ContinueWith(task =>
        {
            LastScreenWidth = CurrentScreenWidth;
            CurrentScreenWidth = task.Result;
            ScreenWidthChanged?.Invoke();
        });
    }
    private async Task<int> GetWindowWidth()
    {
        return await _jSRuntime.InvokeAsync<int>("eval", "window.innerWidth");
    }
}
