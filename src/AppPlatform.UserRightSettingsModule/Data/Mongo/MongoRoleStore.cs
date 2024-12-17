using AppPlatform.Core.Models.Authorization;
using AppPlatform.UserRightSettingsModule.Data.Abstractions;
using MongoDB.Driver;
using System.Security.Claims;
using MongoEnteties = AppPlatform.Data.MongoDb.Enteties.Authorization;

namespace AppPlatform.UserRightSettingsModule.Data.Mongo;
internal class MongoRoleStore
    (
    IMongoCollection<MongoEnteties.Role> roleCollection,
    IMongoCollection<MongoEnteties.UserRole> userRoleCollection
    )
    : IRoleStore
{
    public Task CreateUserRole(string userId, Role role)
    {
        var userRole = userRoleCollection.Find(ur => ur.UserId == userId && ur.RoleId == role.Id).FirstOrDefault();
        if (userRole is null)
        {
            userRole = new MongoEnteties.UserRole
            {
                UserId = userId,
                RoleId = role.Id
            };
            return userRoleCollection.InsertOneAsync(userRole);
        }
        return Task.CompletedTask;
    }

    public Task CreateUserRole(UserRole userRole)
    {
        var mongoUserRole = new MongoEnteties.UserRole
        {
            UserId = userRole.UserId,
            RoleId = userRole.RoleId
        };
        return userRoleCollection.InsertOneAsync(mongoUserRole);
    }

    public Task DeleteRoleAsync(Role role)
    {
        return roleCollection.DeleteOneAsync(r => r.Id == role.Id);
    }

    public Task DeleteUserRole(string userId, Role role)
    {
        return userRoleCollection.DeleteOneAsync(ur => ur.UserId == userId && ur.RoleId == role.Id);
    }

    public Task DeleteUserRole(UserRole userRole)
    {
        return userRoleCollection.DeleteOneAsync(ur => ur.UserId == userRole.UserId && ur.RoleId == userRole.RoleId);
    }

    public Task<Role?> GetRoleAsync(string roleId)
    {
        var mongoRole = roleCollection.Find(r => r.Id == roleId).FirstOrDefault();
        if (mongoRole is null)
        {
            return Task.FromResult<Role?>(null);
        }
        var role = new Role
        {
            Id = mongoRole.Id,
            TenantId = mongoRole.TenantId,
            Name = mongoRole.Name,
            Description = mongoRole.Description
        };
        role.RoleAccesses = mongoRole.AccessClaimValues.Select(acv => new RoleAccess
        {
            RoleId = mongoRole.Id,
            Role = role,
            AccessClaimValue = acv
        }).ToList();
        return Task.FromResult<Role?>(role);
    }

    public Task<List<Role>> GetRolesAsync(string tenantId)
    {
        var mongoRoles = roleCollection.Find(r => r.TenantId == tenantId).ToList();
        var roles = mongoRoles.Select(mr =>
        {
            var role = new Role
            {
                Id = mr.Id,
                TenantId = mr.TenantId,
                Name = mr.Name,
                Description = mr.Description
            };
            role.RoleAccesses = mr.AccessClaimValues.Select(acv => new RoleAccess
            {
                RoleId = mr.Id,
                Role = role,
                AccessClaimValue = acv
            }).ToList();
            return role;
        }).ToList();
        return Task.FromResult(roles);
    }

    public Task<List<UserRole>> GetUserRolesForRoleAsync(string roleId)
    {
        var mongoUserRoles = userRoleCollection.Find(ur => ur.RoleId == roleId).ToList();
        var userRoles = mongoUserRoles.Select(mur => new UserRole
        {
            UserId = mur.UserId,
            RoleId = mur.RoleId
        }).ToList();
        return Task.FromResult(userRoles);
    }

    public Task<List<Role>> GetUserRolesForUserAsync(string userId)
    {
        var mongoUserRoles = userRoleCollection.Find(ur => ur.UserId == userId).ToList();
        var roles = mongoUserRoles.Select(mur =>
        {
            var role = roleCollection.Find(r => r.Id == mur.RoleId).FirstOrDefault();
            if (role is null)
            {
                return null;
            }
            var r = new Role
            {
                Id = role.Id,
                TenantId = role.TenantId,
                Name = role.Name,
                Description = role.Description
            };
            r.RoleAccesses = role.AccessClaimValues.Select(acv => new RoleAccess
            {
                RoleId = role.Id,
                Role = r,
                AccessClaimValue = acv
            }).ToList();
            return r;
        }).Where(r => r is not null).Select(r => r!).ToList();
        return Task.FromResult(roles);
    }

    public Task UpsertRoleAsync(string tenantId, Role role)
    {
        var mongoRole = new MongoEnteties.Role
        {
            Id = role.Id,
            TenantId = tenantId,
            Name = role.Name,
            Description = role.Description,
            AccessClaimValues = role.RoleAccesses.Select(ra => ra.AccessClaimValue).ToList()
        };
        return roleCollection.ReplaceOneAsync(r => r.Id == role.Id, mongoRole, new ReplaceOptions { IsUpsert = true });
    }
}
