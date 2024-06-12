using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal class ViewService(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IViewService
{
    public Task CreateAsync(ClaimsPrincipal userClaims, View view)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(View view)
    {
        throw new NotImplementedException();
    }

    public Task GetAllAsync(ClaimsPrincipal userClaims)
    {
        throw new NotImplementedException();
    }

    public Task GetAsync(string viewId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<View>> GetViewListAsync(ClaimsPrincipal UserClaims)
    {
        var dbContext = await dbContextFactory.CreateDbContextAsync();
        var tenantId = UserClaims.GetTenantId();
        return await dbContext.Views
            .Where(x => x.TenantId == tenantId)
            .ToListAsync();
    }

    public Task UpdateAsync(View view)
    {
        throw new NotImplementedException();
    }
}
