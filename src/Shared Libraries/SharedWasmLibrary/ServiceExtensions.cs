﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedWasmLibrary.Features.Authentication;
using SharedWasmLibrary.Shared.Enteties;
using SharedWasmLibrary.Shared.Services;

namespace SharedWasmLibrary;
public static class ServiceExtensions
{
    public static void UseSharedWasmLibrary(this WebAssemblyHostBuilder builder)//, AppSeedModel applicationSeed)
    {
        builder.Services.AddMsalAuthentication(options =>
        {
            builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
            options.ProviderOptions.DefaultAccessTokenScopes.Add(builder.Configuration.GetSection("ServerApi")["Scopes"]!);
            //options.ProviderOptions.LoginMode = "redirect";
        });

        builder.Services.AddHttpClient("Backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

        builder.Services.AddTransient<StyleService>();
        builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

#if DEBUG

#else

#endif

        var baseUrl = builder.Configuration.GetSection("MicrosoftGraph")["BaseUrl"];
        var scopes = builder.Configuration.GetSection("MicrosoftGraph:Scopes").Get<List<string>>();
        builder.Services.AddGraphClient(baseUrl, scopes);
    }
}
