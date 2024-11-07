using AppPlatform.BidconDatabaseAccess.NewModels;

namespace AppPlatform.BidconDatabaseAccess.Services.SdkAccess;
public interface ISdkCredentialsService
{
    Task<SdkCredentials> GetSdkCredentialsAsync();
}
