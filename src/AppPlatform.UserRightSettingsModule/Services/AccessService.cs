using AppPlatform.Core.Enteties.Authorization;
using AppPlatform.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace AppPlatform.UserRightSettingsModule.Services;
internal class AccessService : IAccessService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

    public AccessService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public Task CreateRoleAccessAsync(RoleAccess roleAccess)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.RoleAccess.Add(roleAccess);
        return context.SaveChangesAsync();
    }

    public Task CreateUserAccessAsync(UserAccess userAccess)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.UserAccess.Add(userAccess);
        return context.SaveChangesAsync();
    }

    public Task DeleteRoleAccessAsync(RoleAccess roleAccess)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.RoleAccess.Remove(roleAccess);
        return context.SaveChangesAsync();
    }

    public Task DeleteUserAccessAsync(UserAccess userAccess)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.UserAccess.Remove(userAccess);
        return context.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoleAccess>> GetRoleAccessClaimValuesAsync(string roleId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var roleAccesses = await context.RoleAccess
            .Where(ra => ra.RoleId == roleId)
            .ToListAsync();
        return roleAccesses ?? new();
    }

    public async Task<IEnumerable<UserAccess>> GetUserAccessClaimValuesAsync(string userId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var userAccesses = await context.UserAccess
            .Where(ua => ua.UserId == userId)
            .ToListAsync();
        return userAccesses ?? new();
    }
}
