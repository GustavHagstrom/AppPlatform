//using System.Reflection.Metadata;
//using System.Runtime.InteropServices;

//public static class Tray
//{
//    [DllImport("User32.dll")]
//    private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);
//    [DllImport("kernel32.dll")]
//    private static extern IntPtr GetConsoleWindow();

//    private const int SW_HIDE = 0;
//    //private const int SW_MINIMIZE = 6;
//    //private const int SW_RESTORE = 7;
//    //private const int SW_SHOW = 8;
//    private const string VERSION = "0.1";
//    private static nint _handle;

//    private static void Initialize()
//    {
//        _handle = GetConsoleWindow();
//        ShowWindow(_handle, SW_HIDE);

//        NotifyIcon notifyIcon = new NotifyIcon
//        {
//            Icon = new Icon("icon.ico"),
//            Visible = true,
//            Text = $"BidconLink - {VERSION}",

//        };
//    }
//    public static void Run()
//    {
//        Initialize();
//        Application.Run();
//    }
//}




