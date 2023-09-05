using BidconLink.Services;

public static class Api
{
    public static void Begin()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<IEstimationQueryService, EstimationQueryService>();
        builder.Services.AddTransient<IConnectionstringService, ConnectionstringService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();

        app.MapControllers();

        Task.Run(app.Run);
    }
}






