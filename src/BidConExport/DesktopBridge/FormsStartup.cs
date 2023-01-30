namespace DesktopBridge;
public class FormsStartup
{
    private readonly Shell _shell;
    private readonly ILogger<FormsStartup> _logger;

    public FormsStartup(Shell shell, ILogger<FormsStartup> logger)
	{
        _shell = shell;
        _logger = logger;
        AddTrayIcon();
    }
    public void Run()
    {
        Application.Run();
    }
    private void AddTrayIcon()
    {
        var ni = new NotifyIcon
        {
            Icon = new Icon("app.ico"),
            Visible = true,
            Text = "BidCon länk",
            ContextMenuStrip = CreateContextMenu(),
        };
    }
    private ContextMenuStrip CreateContextMenu()
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

    private void OnOpenClick(object? sender, EventArgs e)
    {
        _logger.LogInformation("Displaying forms window");
        _shell.Show();
    }

    private void OnExitClick(object? sender, EventArgs e)
    {
        Application.Exit();
    }

}
