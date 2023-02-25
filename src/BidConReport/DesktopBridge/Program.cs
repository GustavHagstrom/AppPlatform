using Serilog;

namespace BidConReport.DesktopBridge;

internal static class Program
{
    private static CancellationTokenSource _cts = new CancellationTokenSource();
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var config = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
            .Enrich.FromLogContext();
#if DEBUG
        config.WriteTo.Debug();
#else
        config.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day);
#endif
        Log.Logger = config.CreateLogger();
        Log.Information("Starting application");

        try
        {    
            Application.ApplicationExit += OnExit;

            var builder = WebApplication.CreateBuilder();
            builder.Host.UseSerilog();
            builder.ConfigureServices();

            var app = builder.Build();
            app.ConfigurePipeline();
            app.StartAsync(_cts.Token);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var startUp = app.Services.GetService<FormsStartup>()!;
            startUp.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Forms terminated unexpectedly");
            Log.CloseAndFlush();
        }
    }
    private static void OnExit(object? sender, EventArgs e)
    {
        _cts.Cancel();
    }
}