using AppPlatform.Core.Enteties.Authorization;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace AppPlatform.UserRightSettingsModule.Services;
internal class RoleService : IRoleService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public RoleService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public Task UpsertRoleAsync(ClaimsPrincipal userClaims, Role role)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var tenantId = userClaims.GetTenantId();
        if (tenantId == null)
        {
            throw new ArgumentNullException(nameof(tenantId));
        }
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

    public Task<List<Role>> GetRolesAsync(ClaimsPrincipal user)
    {
        var tenantId = user.GetTenantId();
        if (tenantId == null)
        {
            throw new ArgumentNullException(nameof(tenantId));
        }
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

    public Task CreateUserRole(ClaimsPrincipal userClaims, Role role)
    {
        var userId = userClaims.GetUserId();
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }
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
    public Task DeleteUserRole(ClaimsPrincipal userClaims, Role role)
    {
        var userId = userClaims.GetUserId();
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }
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
