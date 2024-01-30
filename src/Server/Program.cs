using AppPlatform.Core.Data;
using Microsoft.EntityFrameworkCore;
using AppPlatform.Server.Components;
using AppPlatform.Server;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

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





builder.RegisterApplicationServices();




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

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();
app.Run();


async Task OnTokenValidatedFunc(TokenValidatedContext context)
{
    var dbContextFactory = context.HttpContext.RequestServices.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    var dbContext = dbContextFactory.CreateDbContext();

    //add claims to the user
    context.Principal?.AddIdentity(new ClaimsIdentity(new[] { new Claim("custom-claim", "custom-value") }));
    
    await Task.CompletedTask.ConfigureAwait(false);
}