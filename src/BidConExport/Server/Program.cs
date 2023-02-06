using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

//builder.Services.AddControllersWithViews();

//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
//        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
//            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
//            .AddInMemoryTokenCaches();

//builder.Services.AddAuthorization(options =>
//{
//    options.FallbackPolicy = options.DefaultPolicy;
//});

//builder.Services.AddRazorPages()
//    .AddMicrosoftIdentityUI();

//builder.Services.AddScoped<HttpClient>();

builder.Services.AddBff();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie";
    options.DefaultChallengeScheme = "ms";
    options.DefaultSignOutScheme = "ms";
})
.AddCookie("cookie", options =>
{
    options.Cookie.Name = "__Host-blazor";
    options.Cookie.SameSite = SameSiteMode.Strict;
})
.AddMicrosoftAccount("ms", "Microsoft", options =>
{
    options.ClientId = "d81695e9-e95c-4f86-bbfd-500fab12a331";
    options.ClientSecret = "QFo8Q~By6fcAgRq9dHL5ejbfpBEa5bniCtK.YcxL";
    options.UsePkce = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseBff();
app.UseAuthorization();

app.MapBffManagementEndpoints();

app.MapRazorPages();

app.MapControllers()
    .RequireAuthorization()
    .AsBffApiEndpoint();



app.MapFallbackToFile("index.html");

app.Run();
