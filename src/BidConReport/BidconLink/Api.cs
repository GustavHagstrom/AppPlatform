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

        //builder.Services.AddCors(options =>
        //{
        //    options.AddDefaultPolicy(builder =>
        //    {
        //        builder.AllowAnyOrigin()
        //               .AllowAnyHeader()
        //               .AllowAnyMethod();
        //    });
        //});

        var app = builder.Build();

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

        app.UseRouting();

        app.MapControllers();

        Task.Run(app.Run);
    }
}






