using AppPlatform.BidconDatabaseAccess.Models;
using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess.SdkAccess.Services;
public interface ISdkCredentialsService
{
    Task<SdkCredentials> GetSdkCredentialsAsync();
}
