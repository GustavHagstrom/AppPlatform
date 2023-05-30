using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedWasmLibrary.Features.Authentication;
using SharedWasmLibrary.Shared.Services;

namespace SharedWasmLibrary;
public static class ServiceExtensions
{
    public static void UseSharedWasmLibrary(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddMsalAuthentication(options =>
        {
            builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration.GetSection("ServerApi")["Scopes"]!);
            //options.ProviderOptions.LoginMode = "redirect";
        });

        builder.Services.AddTransient<StyleService>();
        builder.Services.AddScoped<IAuthStateTrigger, AuthStateTrigger>();

        var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
        var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes").Get<List<string>>();
        builder.Services.AddGraphClient(baseUrl, scopes);
    }
}
