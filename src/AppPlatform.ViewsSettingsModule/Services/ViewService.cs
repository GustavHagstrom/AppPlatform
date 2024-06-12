using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal class ViewService(IDbContextFactory<ApplicationDbContext> dbContextFactory) : IViewService
{
    public async Task UpsertAsync(ClaimsPrincipal userClaims, View view)
    {
        ApplicationDbContext dbContext = await dbContextFactory.CreateDbContextAsync();
        var tenantId = userClaims.GetTenantId();
        if (tenantId is null)
        {
            throw new Exception("TenantId is null");
        }
        view.TenantId = tenantId;

        //Adds the view to the database if none is found with the same Id
        var existingView = await dbContext.Views.FirstOrDefaultAsync(x => x.Id == view.Id);
        if (existingView is null)
        {
            await dbContext.Views.AddAsync(view);
            await dbContext.SaveChangesAsync();
        }
        else
        {
            existingView.Name = view.Name;
            await dbContext.SaveChangesAsync();
        }
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
}
