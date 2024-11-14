using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.SdkAccess.Services;
public interface ISdkCredentialsService
{
    Task<SdkCredentials> GetSdkCredentialsAsync();
}
