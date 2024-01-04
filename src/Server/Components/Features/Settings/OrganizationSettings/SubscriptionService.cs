using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using Server.Extensions;
using System.Security.Claims;

namespace Server.Components.Features.Settings.OrganizationSettings;

public class SubscriptionService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<SubscriptionService> logger)
{
    public async Task Upsert(ClaimsPrincipal userClaims, Subscription subscription)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user is null)
        {
            logger.LogWarning("No user found. No action taken.");
            return;
        }
        if (user.ActiveOrganizationId is null)
        {
            logger.LogWarning("No active organization found. No action taken.");
            return;
        }
        var existingSubscription = await dbContext.Licenses.FindAsync(subscription.Id);
        if (existingSubscription is null)
        {
            subscription.OrganizationId = user.ActiveOrganizationId;
            dbContext.Licenses.Add(subscription);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Subscription created {Subscription}", subscription);
        }
        else
        {
            existingSubscription.ExpirationDate = subscription.ExpirationDate;
            existingSubscription.UserLimit = subscription.UserLimit;
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Subscription created {Subscription}", subscription);
        }
    }
    public async Task<Subscription?> GetSubscription(ClaimsPrincipal userClaims)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if(user is null)
        {
            logger.LogWarning("No user found. Subscription not created");
            return null;
        }
        if(user.ActiveOrganizationId is null)
        {
            logger.LogWarning("No active organization found. Subscription not created");
            return null;
        }

        var existingSubscription = await dbContext.Licenses.FirstOrDefaultAsync(x => x.OrganizationId == user.ActiveOrganizationId);
        return existingSubscription;
    }
    public async Task DeleteAsync(ClaimsPrincipal userClaims, Subscription subscription)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Licenses.Remove(subscription);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("Subscription deleted {Subscription}", subscription);
    }
}
