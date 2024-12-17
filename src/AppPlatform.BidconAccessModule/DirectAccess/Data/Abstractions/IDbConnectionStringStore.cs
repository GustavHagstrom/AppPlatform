using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Data.Abstractions;

public interface IDbConnectionStringStore

{
    Task<string> BuildAsync(string tenantId);
}