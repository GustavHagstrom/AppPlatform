﻿using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Builders;
using AppPlatform.Core.Constants;
using AppPlatform.Core.DataAccess.Settings;
using AppPlatform.Core.Services;
using AppPlatform.Data.Abstractions;
using AppPlatform.Data.EfCore.Stores;
using AppPlatform.SharedModule.Components.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Extensions.DependencyInjection;
using AppPlatform.Core.Extensions;
using Microsoft.Graph;
using AppPlatform.Core.Models.FromShared;
using AppPlatform.SharedModule.Services;
using AppPlatform.SharedModule.Services.MicrosoftGraph;
using AppPlatform.SharedModule.Services.Views;
using AppPlatform.Data.MongoDb.Stores;

namespace AppPlatform.SharedModule;
public class SharedModule : IModule
{
    public void ConfigForEfCore(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IDarkModeStore, SqlDarkModeStore>();
        builder.Services.AddTransient<IAccessClaimStore, SqlAccessClaimStore>();
    }

    public void ConfigForMongoDb(WebApplicationBuilder builder, MongoCollectionRegistrar collectionBuilder)
    {
        collectionBuilder.Add<Data.MongoDb.Enteties.UserSettings>("UserSettings");
        collectionBuilder.Add<Data.MongoDb.Enteties.Authorization.Role>("Roles");
        collectionBuilder.Add<Data.MongoDb.Enteties.Authorization.UserAccess>("UserAccess");
        collectionBuilder.Add<Data.MongoDb.Enteties.Authorization.UserRole>("UserRoles");


        builder.Services.AddScoped<IDarkModeStore, MongoDarkModeStore>();
        builder.Services.AddTransient<IAccessClaimStore, MongoAccessClaimStore>();
    }

    public void GeneralConfig(WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization();
        
        builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
        
        builder.Services.AddSingleton<IApplicationRenderComponentsService, ApplicationRenderComponentsService>();
        builder.Services.AddApplicationInjectableComponent<AppbarSettingsLink>(SharedInjectableComponentKeys.AppBarNavLinkComponent);
        builder.Services.AddSingleton<IAccessClaimInfoContainer, AccessClaimInfoContainer>();
        builder.Services.AddAccessClaimInfo<BidconConnectionClaimInfo>();
        builder.Services.AddTransient<IAuthenticationProvider, GraphClientAuthProvider>();
        builder.Services.AddScoped(sp => new GraphServiceClient(sp.GetRequiredService<IAuthenticationProvider>()));
        builder.Services.AddScoped<IMicrosoftGraphUserAccess, GraphClientUserAccess>();
        builder.Services.AddTransient<IViewStyleService, ViewStyleService>();


        //Core services
        builder.Services.AddScoped<ISheetDataService, SheetDataService>();

        builder.Services.AddAuthorization(configure =>
        {
            configure.AddPolicy(SharedAuthorizationPolicies.BidconConnection, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(SharedApplicationClaimTypes.AccessClaim, SharedAccessClaimValues.BidconConnection);
            });
        });
    }

    public void OnEfCoreModelCreating(ModelBuilder modelBuilder)
    {

    }

    public void RegisterAccessIds(AccessClaimInfoBuilder accessIdBuilder)
    {

    }

    public void RegisterInjectableComponents(ComponentBuilder componentBuilder)
    {

    }
}