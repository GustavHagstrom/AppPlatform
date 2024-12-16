using Microsoft.EntityFrameworkCore;
using AppPlatform.Server.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using MudBlazor;
using AppPlatform.Core.Extensions;
using AppPlatform.ViewSettingsModule;
using AppPlatform.UserRightSettingsModule;
using AppPlatform.BidconBrowserModule;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Identity.Client;
using AppPlatform.BidconAccessModule;
using MongoDB.Driver;
using AppPlatform.Data.EfCore;
using AppPlatform.SharedModule;
using AppPlatform.Data.Abstractions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddCascadingAuthenticationState();

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(options =>
            {
                var section = builder.Configuration.GetSection("AzureAd");
                section.Bind(options);
                options.Events.OnTokenValidated += OnTokenValidatedFunc;
            })
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddInMemoryTokenCaches();

        builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();
        if (builder.Configuration["DbType"] == "SqlServer")
        {
#if DEBUG
            var connectionString = "Data Source=bin/debug/database.db";
            builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("AppPlatform.Server")));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#else
    var connectionString = builder.Configuration.GetConnectionString("SqlServer") ?? throw new InvalidOperationException("Connection string 'SqlServer' not found.");
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AppPlatform.Server")));
#endif
        }
        else if (builder.Configuration["DbType"] == "MongoDb")
        {
            builder.Services.AddSingleton(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration["MongoDbSettings:ConnectionString"];
                var dbName = configuration["MongoDbSettings:DatabaseName"];
                if (string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("MongoDB settings are not configured properly.");
                }
                var client = new MongoClient(connectionString);
                return client.GetDatabase(dbName);
            });
            
        }
        else
        {
            throw new InvalidOperationException("DbType not found");
        }



        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 1000 * 5;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;

        });




        builder.ConfigureMonolith(config =>
        {
            config.AddModule<SharedModule>();
            config.AddModule<ViewSettingsModule>();
            config.AddModule<UserRightSettingsModule>();
            config.AddModule<BidconBrowserModule>();
            config.AddModule<BidconAccessModule>();


        }); //add assembly to the route aswell

        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        if (app.Configuration["DbType"] == "SqlServer")
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                    // Log the error or handle it as necessary
                    Console.WriteLine("An error occurred while migrating the database.", ex);
                    throw;
                }
            }
        }
        

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            ExceptionHandler = async ctx =>
            {
                var feature = await Task.FromResult(ctx.Features.Get<IExceptionHandlerFeature>());
                if (feature?.Error is MsalUiRequiredException
                    or { InnerException: MsalUiRequiredException }
                    or { InnerException.InnerException: MsalUiRequiredException })
                {
                    ctx.Response.Cookies.Delete($"{CookieAuthenticationDefaults.CookiePrefix}{CookieAuthenticationDefaults.AuthenticationScheme}");
                    ctx.Response.Redirect(ctx.Request.GetEncodedPathAndQuery());
                }
            }
        });

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddAdditionalAssemblies(
            typeof(SharedModule).Assembly,
            typeof(ViewSettingsModule).Assembly,
            typeof(UserRightSettingsModule).Assembly,
            typeof(BidconBrowserModule).Assembly,
            typeof(BidconAccessModule).Assembly);

        app.MapControllers();
        app.Run();


        async Task OnTokenValidatedFunc(TokenValidatedContext context)
        {
            var accessClaimService = context.HttpContext.RequestServices.GetRequiredService<IAccessClaimStore>();
            if (accessClaimService is not null)
            {
                var claims = (await accessClaimService.GetAccessClaims(context.Principal)).ToList();
                context.Principal?.AddIdentity(new ClaimsIdentity(claims));
            }
            else
            {
                //handle?
            }
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}

#if DEBUG

#else
#endif
