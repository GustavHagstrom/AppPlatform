using AppPlatform.Core.Models.Authorization;
using AppPlatform.UserRightSettingsModule.Data.Abstractions;
using MongoDB.Driver;
using AppPlatform.Data;
using MongoEnteties = AppPlatform.Data.MongoDb.Enteties.Authorization;

namespace AppPlatform.UserRightSettingsModule.Data.Mongo;
internal class MongoAccessStore
    (
    IMongoCollection<MongoEnteties.Role> roleCollection, 
    IMongoCollection<MongoEnteties.UserAccess> userAccessCollection
    ) 
    : IAccessStore
{
    public Task CreateRoleAccessAsync(RoleAccess roleAccess)
    {
        var role = roleCollection.Find(r => r.Id == roleAccess.RoleId).FirstOrDefault();
        if (role is null)
        {
            role = new MongoEnteties.Role
            {
                Id = roleAccess.RoleId,
                AccessClaimValues = new List<string> { roleAccess.AccessClaimValue }
            };
            return roleCollection.InsertOneAsync(role);
        }
        if(!role.AccessClaimValues.Contains(roleAccess.AccessClaimValue))
        {
            role.AccessClaimValues.Add(roleAccess.AccessClaimValue);
            return roleCollection.ReplaceOneAsync(r => r.Id == roleAccess.RoleId, role);
        }
        return Task.CompletedTask;
    }

    public Task CreateUserAccessAsync(UserAccess userAccess)
    {
        var mongoUserAccess = userAccessCollection.Find(u => u.UserId == userAccess.UserId).FirstOrDefault();
        if (mongoUserAccess is null)
        {
            mongoUserAccess = new MongoEnteties.UserAccess
            {
                UserId = userAccess.UserId,
                AccessClaimValues = new List<string> { userAccess.AccessClaimValue }
            };
            return userAccessCollection.InsertOneAsync(mongoUserAccess);
        }
        if (!mongoUserAccess.AccessClaimValues.Contains(userAccess.AccessClaimValue))
        {
            mongoUserAccess.AccessClaimValues.Add(userAccess.AccessClaimValue);
            return userAccessCollection.ReplaceOneAsync(u => u.UserId == userAccess.UserId, mongoUserAccess);
        }
        return Task.CompletedTask;
    }

    public Task DeleteRoleAccessAsync(RoleAccess roleAccess)
    {
        var role = roleCollection.Find(r => r.Id == roleAccess.RoleId).FirstOrDefault();
        if (role is not null && role.AccessClaimValues.Contains(roleAccess.AccessClaimValue))
        {
            role.AccessClaimValues.Remove(roleAccess.AccessClaimValue);
            return roleCollection.ReplaceOneAsync(r => r.Id == roleAccess.RoleId, role);
        }
        return Task.CompletedTask;
    }

    public Task DeleteUserAccessAsync(UserAccess userAccess)
    {
        var mongoUserAccess = userAccessCollection.Find(u => u.UserId == userAccess.UserId).FirstOrDefault();
        if (mongoUserAccess is not null && mongoUserAccess.AccessClaimValues.Contains(userAccess.AccessClaimValue))
        {
            mongoUserAccess.AccessClaimValues.Remove(userAccess.AccessClaimValue);
            return userAccessCollection.ReplaceOneAsync(u => u.UserId == userAccess.UserId, mongoUserAccess);
        }
        return Task.CompletedTask;
    }

    public Task<IEnumerable<RoleAccess>> GetRoleAccessClaimValuesAsync(string roleId)
    {
        var role = roleCollection.Find(r => r.Id == roleId).FirstOrDefault();
        if (role is not null)
        {
            return Task.FromResult(role.AccessClaimValues.Select(acv => new RoleAccess { RoleId = roleId, AccessClaimValue = acv }));
        }
        return Task.FromResult(Enumerable.Empty<RoleAccess>());
    }

    public Task<IEnumerable<UserAccess>> GetUserAccessClaimValuesAsync(string userId)
    {
        var mongoUserAccess = userAccessCollection.Find(u => u.UserId == userId).FirstOrDefault();
        if (mongoUserAccess is not null)
        {
            return Task.FromResult(mongoUserAccess.AccessClaimValues.Select(acv => new UserAccess { UserId = userId, AccessClaimValue = acv }));
        }
        return Task.FromResult(Enumerable.Empty<UserAccess>());
    }
}
