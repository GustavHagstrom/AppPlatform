using AppPlatform.Core.Models.Authorization;
using AppPlatform.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using AppPlatform.Data.EfCore;
using AppPlatform.UserRightSettingsModule.Data.Abstractions;

namespace AppPlatform.UserRightSettingsModule.Data.EfCore;
internal class SqlRoleStore : IRoleStore
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public SqlRoleStore(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public Task UpsertRoleAsync(string tenantId, Role role)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var existingRole = context.Roles.FirstOrDefault(x => x.Id == role.Id);
        if (existingRole != null)
        {
            existingRole.Name = role.Name;
            existingRole.Description = role.Description;
            existingRole.TenantId = tenantId;
            context.Roles.Update(existingRole);
        }
        else
        {
            role.TenantId = tenantId;
            context.Roles.Add(role);
        }
        return context.SaveChangesAsync();
    }

    public Task DeleteRoleAsync(Role role)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Roles.Remove(role);
        return context.SaveChangesAsync();
    }

    public Task<Role?> GetRoleAsync(string roleId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
    }

    public Task<List<Role>> GetRolesAsync(string tenantId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.Roles.Where(x => x.TenantId == tenantId).ToListAsync();
    }

    public async Task<List<Role>> GetUserRolesForUserAsync(string userId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var result = await context.UserRoles.Include(x => x.Role)
            .Where(x => x.UserId == userId)
            .Select(x => x.Role)
            .ToListAsync();
        var roles = result?.Where(x => x is not null).Select(x => x!).ToList();
        return roles ?? new List<Role>();

    }

    public Task<List<UserRole>> GetUserRolesForRoleAsync(string roleId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.UserRoles.Where(x => x.RoleId == roleId).ToListAsync();
    }

    public Task CreateUserRole(string userId, Role role)
    {
        var userRole = new UserRole
        {
            RoleId = role.Id,
            UserId = userId
        };
        return CreateUserRole(userRole);
    }
    public Task CreateUserRole(UserRole userRole)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.UserRoles.Add(userRole);
        return context.SaveChangesAsync();
    }
    public Task DeleteUserRole(string userId, Role role)
    {
        var userRole = new UserRole
        {
            RoleId = role.Id,
            UserId = userId
        };
        return DeleteUserRole(userRole);
    }
    public Task DeleteUserRole(UserRole userRole)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var existingUserRole = context.UserRoles.FirstOrDefault(x => x.RoleId == userRole.RoleId && x.UserId == userRole.UserId);
        if (existingUserRole != null)
        {
            context.UserRoles.Remove(existingUserRole);
        }
        return context.SaveChangesAsync();
    }
}
