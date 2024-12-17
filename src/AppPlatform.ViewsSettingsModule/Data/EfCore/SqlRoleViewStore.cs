using AppPlatform.Core.Models.Authorization;
using AppPlatform.Core.Models.EstimationView;
using AppPlatform.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppPlatform.Data.EfCore;
using AppPlatform.ViewSettingsModule.Data.Abstractions;

namespace AppPlatform.ViewSettingsModule.Data.EfCore;
internal class SqlRoleViewStore(IDbContextFactory<ApplicationDbContext> contextFactory) : IRoleViewStore
{
    public async Task<IEnumerable<Role>> GetRolesAsync(string tenantId)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        return await context.Roles.Where(x => x.TenantId == tenantId).ToListAsync();
    }
    public async Task<IEnumerable<string>> GetPickedRoleIdsAsync(View view)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        return await context.RoleViews
            .Where(x => x.ViewId == view.Id)
            .Select(x => x.RoleId)
            .ToListAsync();
    }
    public async Task PickAsync(View view, IEnumerable<string> roleIds)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var roleViews = roleIds.Select(x => new RoleView
        {
            RoleId = x,
            ViewId = view.Id
        });
        await context.RoleViews.AddRangeAsync(roleViews);
        await context.SaveChangesAsync();
    }
    public async Task UnpickAsync(View view, IEnumerable<string> roleIds)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var roleViews = await context.RoleViews
            .Where(x => x.ViewId == view.Id && roleIds.Contains(x.RoleId))
            .ToListAsync();
        context.RoleViews.RemoveRange(roleViews);
        await context.SaveChangesAsync();
    }
}

