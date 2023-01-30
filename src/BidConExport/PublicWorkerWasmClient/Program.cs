using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PublicWorkerWasmClient;
using ApiAccessLibrary.Extensions;
using SharedLibrary.Extensions;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using PublicWorkerWasmClient.Authentication.Services;
using MudBlazor;
using PublicWorkerWasmClient.Logic.Estimation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddApiAccessLibrary(new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("APICLIENT_BASEADDRESS")) });
builder.Services.AddSharedLibrary();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<ITokenManagerService, TokenManagerService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthProviderService>();
builder.Services.AddTransient<IEstimationImportState, EstimationImportState>();
builder.Services.AddTransient<IEstimationImportSettingsState, EstimationImportSettingsState>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});


await builder.Build().RunAsync();



