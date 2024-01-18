using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AppPlatform.Core.Extensions;

namespace AppPlatform.Core.Services.Settings;

public class BidconCredentialsService(IDbContextFactory<ApplicationDbContext> ContextFactory) : IBidconCredentialsService
{
    public async Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal userClaims)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if(user?.ActiveOrganizationId is null)
        {
            return null;
        }
        var result = await dbContext.BidconAccessCredentials.FirstOrDefaultAsync(x => x.OrganizationId == user.ActiveOrganizationId);
        return result;
    }

    public async Task UpsertAsync(ClaimsPrincipal userClaims, BidconAccessCredentials credentials)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user?.ActiveOrganizationId is null)
        {
            return;
        }
        
        credentials.OrganizationId = user.ActiveOrganizationId;
        var existingCredentials = await dbContext.BidconAccessCredentials
            .FirstOrDefaultAsync(x => x.OrganizationId == credentials.OrganizationId);
        if (existingCredentials is null)
        {
            // Insert a new record if it doesn't exist

            credentials.LastUpdated = DateTime.UtcNow;
            dbContext.BidconAccessCredentials.Add(credentials);
        }
        else
        {
            // Update the existing record if it exists
            existingCredentials.OrganizationId = credentials.OrganizationId;
            existingCredentials.Server = credentials.Server;
            existingCredentials.Database = credentials.Database;
            existingCredentials.User = credentials.User;
            existingCredentials.Password = credentials.Password;
            existingCredentials.ServerAuthentication = credentials.ServerAuthentication;
            existingCredentials.LastUpdated = DateTime.Now;
        }
        await dbContext.SaveChangesAsync();
        
    }
}
