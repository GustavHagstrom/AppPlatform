using BidConReport.Client;
using BidConReport.Client.Features.Authentication;
using BidConReport.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient(AppConstants.BidConApiHttpClientName, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BidConApiAddress")!);
});
builder.Services.AddHttpClient(AppConstants.BackendHttpClientName, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(AppConstants.BackendHttpClientName));


var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes").Get<List<string>>();
builder.Services.AddGraphClient(baseUrl, scopes);


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


builder.Services.AddLocalization();


builder.Services.UseImportFeature();
builder.Services.UseAuthenticationFeature();
builder.Services.UseSharedStateContainers();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration.GetSection("ServerApi")["Scopes"]!);
    options.ProviderOptions.LoginMode = "redirect";
});

await builder.Build().RunAsync();
