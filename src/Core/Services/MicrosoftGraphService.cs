using Microsoft.Identity.Client;

namespace AppPlatform.Core.Services;
public class MicrosoftGraphService(string clientId, string clientSecret)
{
    //private readonly string[] scopes = ["https://graph.microsoft.com/.default", "Organization.Read.All/.default"];
    private readonly string[] scopes = ["https://graph.microsoft.com/.default"];
    private const string tenantId = "common";
    public async Task GivePermissionAsync()
    {
        var cca = ConfidentialClientApplicationBuilder
            .Create(clientId)
            .WithClientSecret(clientSecret)
            .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}"))
            .Build();

        bool loggedinUserInformation = false;
        if (loggedinUserInformation)
        {
            //Implement. Get IAccount from MSAL signed in user. this should be based on the objectId ?? Object ID should be stored in user table in application database??
            throw new NotImplementedException();
        }
        else
        {
            var result = await cca.AcquireTokenForClient(scopes).WithForceRefresh(true).ExecuteAsync();
                                  //.WithPrompt(Prompt.SelectAccount)
                                  //.ExecuteAsync();
            //var account = await cca.GetAccountsAsync();
            //var result = await cca.AcquireTokenSilent(scopes, account.FirstOrDefault())
            //    .ExecuteAsync();
            //return result.AccessToken;
        }

        //var account = await cca.GetAccountsAsync();
        //var result = await cca. AcquireTokenForClient(scopes)
        //    .ExecuteAsync();

        
        //var accessToken = result.AccessToken;

        //return accessToken;
    }
}
