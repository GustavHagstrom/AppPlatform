using AppPlatform.Core.Models;

namespace AppPlatform.BidconAccessModule.SdkAccess.Data.Abstractions;
public interface ISdkCredentialsStore
{
    Task<SdkCredentials?> GetSdkCredentialsAsync(string tenantId);
    Task UpsertCredentialsAsync(string tenantId, SdkCredentials credentials);
}
