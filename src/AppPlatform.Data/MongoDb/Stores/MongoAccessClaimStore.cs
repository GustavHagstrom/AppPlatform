using AppPlatform.Core.Extensions;
using AppPlatform.Core.Models.FromShared;
using AppPlatform.Data.Abstractions;
using AppPlatform.Data.MongoDb.Enteties.Authorization;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Security.Claims;

namespace AppPlatform.Data.MongoDb.Stores;
public class MongoAccessClaimStore
    (
    IMongoCollection<Role> roleCollection,
    IMongoCollection<UserAccess> userAccessCollection,
    IMongoCollection<UserRole> userRoleCollection,
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

        
        var userRoles = await userRoleCollection.Find(Builders<UserRole>.Filter.Eq(nameof(UserRole.UserId), userId)).ToListAsync();
        var userAccesses = await userAccessCollection.Find(Builders<UserAccess>.Filter.Eq(nameof(UserAccess.UserId), userId)).ToListAsync();
        var accessClaims = new List<AccessClaim>();
        foreach (var userRole in userRoles)
        {
            var role = await roleCollection.Find(Builders<Role>.Filter.Eq(nameof(Role.Id), userRole.RoleId)).FirstOrDefaultAsync();
            if (role == null)
            {
                logger.LogWarning("Role not found");
                continue;
            }
            accessClaims.AddRange(role.AccessClaimValues.Select(ac => new AccessClaim(ac)));
        }
        accessClaims.AddRange(userAccesses.Select(ua => new AccessClaim(ua.AccessClaimValue)));
        return accessClaims;
    }
}
