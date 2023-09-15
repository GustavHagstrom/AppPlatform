using BidConReport.Client;
using BidConReport.Client.Shared.Constants;
using BidConReport.Client.Shared.Extensions;
using BidConReport.Shared.Constants;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using SharedWasmLibrary;
using SharedPlatformLibrary;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//http client for BidconAccess
builder.Services.AddHttpClient(HttpClientNames.BidconLink, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("DesktopBridgeAddress")!);
});

//Default httpclient for the backend
builder.Services.AddHttpClient(HttpClientNames.BackendHttpClientName, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

//Scoped instance of backend http client. Injecting a http cliet directly will result in this instance
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(HttpClientNames.BackendHttpClientName));

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
builder.Services.UseSharedServices(); //Should probably be moved and integrated into this project
builder.Services.UseSharedPlatformLibrary(); //Should probably be moved and integrated into this project
builder.UseSharedWasmLibrary(BackendApiEndpoints.ClaimEnpoints.Get); //Should probably be moved and integrated into this project

builder.Services.AddAuthorizationCore(options =>
{
    options.AddCustomPolicies(); //Extension that adds all requried policies.
});

await builder.Build().RunAsync();
