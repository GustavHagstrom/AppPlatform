using BidCon.SDK.Database;

namespace AppPlatform.BidconDatabaseAccess.Services.SdkAccess;
internal class BidconSdkAccess : IBidconAccess
{
    private readonly Lazy<Task<DatabaseUser>> _lazyUser;
    private readonly ISdkCredentialsService _sdkCredentialsService;

    public BidconSdkAccess(ISdkCredentialsService sdkCredentialsService)
    {
        _lazyUser = new Lazy<Task<DatabaseUser>>(UserLazyLoadAsync);
        _sdkCredentialsService = sdkCredentialsService;
    }
    private async Task<DatabaseUser> UserLazyLoadAsync()
    {
        var credentials = await _sdkCredentialsService.GetSdkCredentialsAsync();
        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromConfig(credentials.ConfigPath);
        var user = app.Login(credentials.User, credentials.Password);
        return user;
    }
}
