using Server.Data;
using Server.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Server.Extensions;

namespace Server.Services.Settings;

public class BidconCredentialsService(IDbContextFactory<ApplicationDbContext> ContextFactory) : IBidconCredentialsService
{
    public async Task<BidconAccessCredentials?> GetAsync(ClaimsPrincipal user)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var orgId = user.GetOrganizationId();
        if(orgId is null)
        {
            return null;
        }
        var result = await dbContext.BidconAccessCredentials.FirstOrDefaultAsync(x => x.OrganizationId == Guid.Parse(orgId));
        return result;
    }

    public async Task UpsertAsync(ClaimsPrincipal user, BidconAccessCredentials credentials)
    {
        var dbContext = ContextFactory.CreateDbContext();
        var orgId = user.GetOrganizationId();
        if (orgId is not null)
        {
            var existingCredentials = await dbContext.BidconAccessCredentials.FindAsync(orgId);
            if (existingCredentials is null)
            {
                // Insert a new record if it doesn't exist

                credentials.LastUpdated = DateTime.UtcNow;
                dbContext.BidconAccessCredentials.Add(credentials);
            }
            else
            {
                // Update the existing record if it exists
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
}
