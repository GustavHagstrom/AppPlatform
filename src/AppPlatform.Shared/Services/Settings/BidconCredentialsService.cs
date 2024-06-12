﻿using AppPlatform.Core.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppPlatform.Shared.Extensions;
using AppPlatform.Shared.Data;

namespace AppPlatform.Shared.Services.Settings;

public class BidconCredentialsService(IDbContextFactory<ApplicationDbContext> ContextFactory) : IBidconCredentialsService
{
    public async Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims)
    {
        var tenantId = userClaims.GetTenantId();
        if (tenantId is null)
        {
            return null;
        }
        var dbContext = ContextFactory.CreateDbContext();
        var result = await dbContext.BidconAccessCredentials.FirstOrDefaultAsync(x => x.TenantId == tenantId);
        return result;
    }

    public async Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentials)
    {
        var tenantId = userClaims.GetTenantId();
        if (tenantId is null)
        {
            return;
        }
        credentials.TenantId = tenantId;
        var dbContext = ContextFactory.CreateDbContext();
        var existingCredentials = await dbContext.BidconAccessCredentials
            .FirstOrDefaultAsync(x => x.TenantId == tenantId);
        if (existingCredentials is null)
        {
            // Insert a new record if it doesn't exist

            dbContext.BidconAccessCredentials.Add(credentials);
        }
        else
        {
            // Update the existing record if it exists
            existingCredentials.TenantId = tenantId;
            existingCredentials.Server = credentials.Server;
            existingCredentials.Database = credentials.Database;
            existingCredentials.User = credentials.User;
            existingCredentials.Password = credentials.Password;
            existingCredentials.ServerAuthentication = credentials.ServerAuthentication;
            existingCredentials.UseDesktopBidconLink = credentials.UseDesktopBidconLink;
        }
        await dbContext.SaveChangesAsync();
        
    }
}
