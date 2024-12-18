﻿using  AppPlatform.BidconLink.Services;
using Serilog;
using AppPlatform.BidconDatabaseAccess;

var loggerConfig = new LoggerConfiguration();

#if DEBUG

#else
ConsoleWindow.Hide();
loggerConfig.WriteTo.File("logs/log.txt", 
    rollingInterval: RollingInterval.Day,
    retainedFileCountLimit: 10);
#endif

const string VERSION = "0.1";

var logger = loggerConfig
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information($"Version: {VERSION}");


//TODO: Check for updates


var builder = WebApplication.CreateBuilder();
logger.Information($"Adding services");

builder.Services.AddLogging(logging =>
{
    logging.AddSerilog(logger);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBidconConfigService, BidconConfigService>();
builder.Services.UseBidconDirectDbAccess<ConnectionstringService>();

var app = builder.Build();

logger.Information($"Configuring pipeline");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

logger.Information($"Starting application");
app.Run();