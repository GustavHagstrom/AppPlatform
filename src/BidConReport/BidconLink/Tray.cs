using System.Reflection.Metadata;
using System.Runtime.InteropServices;

public static class Tray
{
    [DllImport("User32.dll")]
    private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();


    private const int SW_HIDE = 0;
    private const int SW_MINIMIZE = 6;
    private const int SW_RESTORE = 7;
    private const int SW_SHOW = 8;
    private const string VERSION = "0.1";
    private static readonly CancellationTokenSource _cts = new CancellationTokenSource();
    private static nint _handle;

    delegate bool ConsoleCtrlDelegate(CtrlTypes ctrlType);
    static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
    {
        switch (ctrlType)
        {
            case CtrlTypes.CTRL_C_EVENT:
            case CtrlTypes.CTRL_BREAK_EVENT:
            case CtrlTypes.CTRL_CLOSE_EVENT:
            case CtrlTypes.CTRL_LOGOFF_EVENT:
            case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
                return true;
            default:
                return false;
        }
    }

    enum CtrlTypes : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT,
        CTRL_CLOSE_EVENT,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT
    }


    private static void Initialize()
    {
        SetConsoleCtrlHandler(new ConsoleCtrlDelegate(ConsoleCtrlCheck), true);
        _handle = GetConsoleWindow();
        ShowWindow(_handle, SW_HIDE);

        NotifyIcon notifyIcon = new NotifyIcon
        {
            Icon = new Icon("icon.ico"),
            Visible = true,
            Text = $"BidconLink - {VERSION}",
            ContextMenuStrip = CreateContextMenu(),

        };

        notifyIcon.DoubleClick += (sender, e) =>
        {
            ShowWindow(_handle, SW_RESTORE);
        };

        //Application.ApplicationExit += Application_ApplicationExit;
    }
    public static void Run()
    {
        Initialize();
        Application.Run();
    }

    //private static void Application_ApplicationExit(object? sender, EventArgs e)
    //{
    //    _cts.Cancel();
    //    ShowWindow(_handle, SW_HIDE);
    //}

    private static ContextMenuStrip CreateContextMenu()
    {
        var contextMenu = new ContextMenuStrip();
        var exitItem = new ToolStripMenuItem("Exit");
        var openItem = new ToolStripMenuItem("Open");
        exitItem.Click += OnExitClick;
        openItem.Click += OnOpenClick;
        contextMenu.Items.Add(exitItem);
        contextMenu.Items.Add(openItem);
        return contextMenu;
    }

    private static void OnOpenClick(object? sender, EventArgs e)
    {
        var a = "sadf";
    }

    private static void OnExitClick(object? sender, EventArgs e)
    {
        var a = "sadf";
    }

    

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate callback, bool add);
}




