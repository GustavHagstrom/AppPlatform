using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using System.Security.Claims;

namespace Server.Components.Features.Settings.OrganizationSettings;

public class SubscriptionService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<SubscriptionService> logger)
{
    public async Task Update(ClaimsPrincipal userClaims, Organization organization)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var existingOrganization = await dbContext.Organizations.FindAsync(organization.Id);
        if (existingOrganization is null)
        {
            logger.LogWarning("No active organization found. No action taken.");
        }
        else
        {
            existingOrganization.ExpireDate = organization.ExpireDate;
            existingOrganization.UserLimit = organization.UserLimit;
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Subscription details for {Organization} updated", organization);
        }
    }
}
