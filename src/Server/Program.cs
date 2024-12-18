using Microsoft.EntityFrameworkCore;
using AppPlatform.Server.Components;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using MudBlazor;
using AppPlatform.Shared.Extensions;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Services.Authorization;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Components;
using AppPlatform.ViewSettingsModule;
using Microsoft.AspNetCore.Builder;
using AppPlatform.UserRightSettingsModule;
using AppPlatform.BidconBrowserModule;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Identity.Client;
using AppPlatform.BidconAccessModule;

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

#if DEBUG
var connectionString = "Data Source=bin/debug/database.db";
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("AppPlatform.Server")));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#else
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AppPlatform.Server")));
#endif


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




builder.Services.AddModules(moduleBuilder =>
{
    moduleBuilder.AddModule<ViewSettingsModule>();
    moduleBuilder.AddModule<UserRightSettingsModule>();
    moduleBuilder.AddModule<BidconBrowserModule>();
    moduleBuilder.AddModule<BidconAccessModule>();
}); //add assembly to the route aswell

builder.Services.RegisterSharedServices();

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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = async ctx => {
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
    .AddAdditionalAssemblies(typeof(MainLayout).Assembly, 
    typeof(ViewSettingsModule).Assembly,
    typeof(UserRightSettingsModule).Assembly,
    typeof(BidconBrowserModule).Assembly,
    typeof(BidconAccessModule).Assembly);

app.MapControllers();
app.Run();


async Task OnTokenValidatedFunc(TokenValidatedContext context)
{
    var accessClaimService = context.HttpContext.RequestServices.GetRequiredService<IAccessClaimService>();
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