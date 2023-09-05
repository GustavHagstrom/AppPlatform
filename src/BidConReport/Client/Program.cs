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

builder.Services.AddHttpClient(HttpClientNames.BidconLink, client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("DesktopBridgeAddress")!);
});
builder.Services.AddHttpClient(HttpClientNames.BackendHttpClientName, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

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
builder.Services.UseImportFeature();
builder.Services.UseSharedStateContainers();
builder.Services.UseSharedServices();
builder.Services.UseSharedPlatformLibrary();
builder.UseSharedWasmLibrary(BackendApiEndpoints.ClaimEnpoints.Get);


await builder.Build().RunAsync();
