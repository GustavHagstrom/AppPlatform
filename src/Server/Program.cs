using AppPlatform.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using AppPlatform.Server.Components.Features.Account;
using Microsoft.AspNetCore.Identity;
using AppPlatform.Core.Enteties;
using AppPlatform.Server.Components;
using AppPlatform.Server;
using AppPlatform.Server.Components.Features.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

//builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultScheme = IdentityConstants.ApplicationScheme;
//        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//    })
//    .AddMicrosoftAccount(options =>
//    {
//        options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"]!;
//        options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"]!;
//    })
//    .AddIdentityCookies();
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    //.AddCookie()
    .AddOpenIdConnect("EntraId", options =>
    {
        //options.Authority = "https://login.microsoftonline.com/common/v2.0";
        options.Authority = "https://login.microsoftonline.com/9d0a59b5-4fcb-477e-bdac-61281aff99fd/v2.0"; 

        options.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"]!;
        options.ResponseType = "code";
        options.SaveTokens = true;
        //options.Scope.Add("https://graph.microsoft.com/.default");
        //options.Scope.Add("openid");
        //options.Scope.Add("profile");
        //options.Scope.Add("User.Read");
        //options.Scope.Add("Organization.Read.All");

        //options.CallbackPath = "/signin-oidc"; // Modify as needed
        //options.SignedOutCallbackPath = "/signout-callback-oidc"; // Modify as needed

    })
    .AddIdentityCookies();

#if DEBUG
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
var connectionString = "Data Source=bin/debug/database.db";
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#else
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
#endif



builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsPrincipalFactory>();

builder.RegisterApplicationServices();


builder.Services.AddSingleton<IEmailSender<User>, IdentityNoOpEmailSender>();

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
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AppPlatform.Client.UserInfo).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
