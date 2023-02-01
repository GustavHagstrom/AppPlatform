using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    private static IConfiguration _configuration;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(), 
            new IdentityResource("organization", new [] {"organization", "organizationId"})

        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            //new ApiScope("api1", "My API"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // machine to machine client
            //new Client
            //{
            //    ClientId = "client",
            //    ClientSecrets = { new Secret("secret".Sha256()) },

            //    AllowedGrantTypes = GrantTypes.ClientCredentials,
            //    // scopes that client has access to
            //    AllowedScopes = { "api1" }
            //},
                
            // interactive ASP.NET Core Web App
            //new Client
            //{
            //    ClientId = "web",
            //    ClientSecrets = { new Secret("secret".Sha256()) },

            //    AllowedGrantTypes = GrantTypes.Code,
                    
            //    // where to redirect to after login
            //    RedirectUris = { "https://localhost:5002/signin-oidc" },

            //    // where to redirect to after logout
            //    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

            //    AllowOfflineAccess = true,

            //    AllowedScopes = new List<string>
            //    {
            //        IdentityServerConstants.StandardScopes.OpenId,
            //        IdentityServerConstants.StandardScopes.Profile,
            //        "api1",
            //        "color",
            //    }
            //},
            new Client
            {
                ClientId = "bff",

                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { _configuration.GetValue<string>("RedirectUris") },
                FrontChannelLogoutUri = _configuration.GetValue<string>("FrontChannelLogoutUri") ,
                PostLogoutRedirectUris = { _configuration.GetValue<string>("PostLogoutRedirectUris")  },

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "organization"
                }
            }
        };
}
