using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.BidconDatabaseAccess.Services.SdkAccess;
public interface ISdkCredentialsService
{
    Task<SdkCredentials> GetSdkCredentialsAsync();
}
