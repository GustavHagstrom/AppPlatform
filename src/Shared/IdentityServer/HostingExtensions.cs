using Duende.IdentityServer;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Duende.IdentityServer.Test;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();


        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        //builder.Services
        //    .AddIdentityServer(options =>
        //    {
        //        options.Events.RaiseErrorEvents = true;
        //        options.Events.RaiseInformationEvents = true;
        //        options.Events.RaiseFailureEvents = true;
        //        options.Events.RaiseSuccessEvents = true;

        //        // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
        //        options.EmitStaticAudienceClaim = true;
        //    })
        //    .AddInMemoryIdentityResources(Config.IdentityResources)
        //    .AddInMemoryApiScopes(Config.ApiScopes)
        //    .AddInMemoryClients(Config.Clients);

        builder.Services.AddIdentityServer()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddAspNetIdentity<ApplicationUser>()
            .AddProfileService<CustomProfileService>();

        builder.Services.AddAuthentication()
            .AddMicrosoftAccount("Microsoft", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                options.ClientId = "d81695e9-e95c-4f86-bbfd-500fab12a331";
                options.ClientSecret = "gEt8Q~b8xP1yxsMrQVIDTVnFvaNkz3UQlDU.oaNh";
            });

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        SeedData.EnsureSeedData(app);

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        
        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}