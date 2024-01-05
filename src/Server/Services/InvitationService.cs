using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using System.Security.Claims;
using Server.Extensions;

namespace Server.Services;

public class InvitationService(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<InvitationService> logger) : IInvitationService
{
    public async Task<OrganizationInvitaion?> GetAsync(string Id)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var invitation = await dbContext.OrganizationInvitaions.FindAsync(Id);
        return invitation;
    }
    public async Task Create(ClaimsPrincipal userClaims, OrganizationInvitaion invitation)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user?.ActiveOrganizationId is null)
        {
            logger.LogWarning("{User} has no active organization", user);
            return;
        }
        invitation.OrganizationId = user.ActiveOrganizationId;
        await dbContext.OrganizationInvitaions.AddAsync(invitation);
        await dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(OrganizationInvitaion invitation)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var existingInvitation = await dbContext.OrganizationInvitaions.FindAsync(invitation.Id);
        if (existingInvitation is null)
        {
            logger.LogWarning("Invitation {Id} not found", invitation.Id);
            return;
        }
        existingInvitation.Status = invitation.Status;
        dbContext.OrganizationInvitaions.Update(invitation);
        await dbContext.SaveChangesAsync();
    }
    public async Task AcceptInvitaionAsync(ClaimsPrincipal userClaims, OrganizationInvitaion invitaion)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if(user is null)
        {
            logger.LogWarning("User {UserId} not found", userClaims.GetUserId());
            return;
        }
        var userOrg = new UserOrganization
        {
            OrganizationId = invitaion.OrganizationId,
            UserId = user.Id
        };
        user.ActiveOrganizationId = invitaion.OrganizationId;
        dbContext.Users.Update(user);
        dbContext.UserOrganizations.Add(userOrg);
        await dbContext.SaveChangesAsync();
    }
}
