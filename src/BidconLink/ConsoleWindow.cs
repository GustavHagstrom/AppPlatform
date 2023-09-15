using System.Runtime.InteropServices;

namespace BidconLink;

public static class ConsoleWindow
{
    [DllImport("User32.dll")]
    private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    private const int SW_HIDE = 0;
    private const int SW_SHOW = 8;

    public static void Hide()
    {
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_HIDE);
    }
    public static void Show()
    {
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_SHOW);
    }
}
