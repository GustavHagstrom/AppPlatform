using AppPlatform.Core.Extensions;
using AppPlatform.Core.Models.Authorization;
using AppPlatform.Core.Models.FromShared;
using AppPlatform.Data.Abstractions;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AppPlatform.Data.MongoDb.Stores;
public class MongoAccessClaimStore
    (
    IDataStore<Role> roleStore, 
    IDataStore<UserAccess> userAccessStore,
    IDataStore<UserRole> userRoleStore, 
    ILogger<MongoAccessClaimStore> logger
    ) 
    : IAccessClaimStore
{

    public Task<IEnumerable<AccessClaim>> GetAccessClaims(ClaimsPrincipal? userClaims)
    {
        var userId = userClaims?.GetUserId();
        if (userId == null)
        {
            logger.LogWarning("User id is null");
            return Task.FromResult(Enumerable.Empty<AccessClaim>());
        }

        return GetAccessClaims(userId);
    }

    public async Task<IEnumerable<AccessClaim>> GetAccessClaims(string userId)
    {

        
        var userRoles = await userRoleStore.GetByIdAsync(ur => ur.UserId == userId);
        var userAccesses = await userAccessStore.GetByAsync(ua => ua.UserId == userId);
        var accessClaims = new List<AccessClaim>();
        foreach (var userRole in userRoles)
        {
            var role = await roleStore.GetByIdAsync(userRole.RoleId);
            if (role == null)
            {
                logger.LogWarning("Role not found");
                continue;
            }
            accessClaims.AddRange(role.AccessClaims.Select(ac => new AccessClaim(ac)));
        }
        accessClaims.AddRange(userAccesses.Select(ua => new AccessClaim(ua.AccessClaim)));
        return accessClaims;
    }
}
