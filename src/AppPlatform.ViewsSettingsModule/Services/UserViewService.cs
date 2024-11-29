using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal class UserViewService(IDbContextFactory<ApplicationDbContext> contextFactory) : IUserViewService
{
    public async Task<IEnumerable<string>> GetPickedUserIdsAsync(ClaimsPrincipal userClaims, View view)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        return await context.UserViews
            .Where(x => x.ViewId == view.Id)
            .Select(x => x.UserId)
            .ToListAsync();
    }
    public async Task PickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> userIds)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var userViews = userIds.Select(x => new UserView
        {
            UserId = x,
            ViewId = view.Id
        });
        await context.UserViews.AddRangeAsync(userViews);
        await context.SaveChangesAsync();
    }
    public async Task UnpickAsync(ClaimsPrincipal userClaims, View view, IEnumerable<string> userIds)
    {
        using var context = await contextFactory.CreateDbContextAsync();
        var userViews = await context.UserViews
            .Where(x => x.ViewId == view.Id && userIds.Contains(x.UserId))
            .ToListAsync();
        context.UserViews.RemoveRange(userViews);
        await context.SaveChangesAsync();
    }
}
