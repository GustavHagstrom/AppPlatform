using BidConReport.DesktopBridge;
using BidConReport.DesktopBridge.Features.Bidcon;

namespace BidConReport.DesktopBridge;

public static class HostingExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<Shell>();
        builder.Services.AddSingleton<FormsStartup>();
        builder.Services.UseBidconFeature();

    }
    public static void ConfigurePipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
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

        //app.UseAuthorization();

        app.MapControllers();
    }
}
