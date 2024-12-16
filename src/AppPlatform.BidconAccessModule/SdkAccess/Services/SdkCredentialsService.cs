using AppPlatform.Core.Models;
using AppPlatform.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppPlatform.Data.EfCore;

namespace AppPlatform.BidconAccessModule.SdkAccess.Services;
internal class SdkCredentialsService(IDbContextFactory<ApplicationDbContext> contextFactory) : ISdkCredentialsService
{
    public Task<SdkCredentials?> GetSdkCredentialsAsync(ClaimsPrincipal userClaims)
    {
        var tenantId = userClaims.GetTenantId();
        if (tenantId is null) return Task.FromResult<SdkCredentials?>(null);

        using var context = contextFactory.CreateDbContext();
        var result = context.SdkCredentials.Where(c => c.TenantId == tenantId).FirstOrDefaultAsync();
        return result;
    }
    public Task UpsertCredentialsAsync(ClaimsPrincipal userClaims, SdkCredentials credentials)
    {
        var tenantId = userClaims.GetTenantId();
        if (tenantId is null) return Task.FromResult(0);

        using var context = contextFactory.CreateDbContext();

        //Check if credentials exists before updating or inserting
        var existingCredentials = context.SdkCredentials.Where(c => c.TenantId == tenantId).FirstOrDefault();

        if(existingCredentials is null)
        {
            credentials.TenantId = tenantId;
            context.SdkCredentials.Add(credentials);
        }
        else
        {
            existingCredentials.User = credentials.User;
            existingCredentials.Password = credentials.Password;
            existingCredentials.ConfigPath = credentials.ConfigPath;
        }
        return context.SaveChangesAsync();
    }
}
