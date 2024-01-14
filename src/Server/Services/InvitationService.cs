using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using System.Security.Claims;
using Server.Extensions;
using Server.Services.Email;
using SharedLibrary.Constants;
using Microsoft.AspNetCore.Components;

namespace Server.Services;

public class InvitationService(
    IDbContextFactory<ApplicationDbContext> dbContextFactory, 
    ILogger<InvitationService> logger, 
    IEmailService emailService,
    NavigationManager navigationManager) : IInvitationService
{
    public async Task<OrganizationInvitaion?> GetAsync(string Id)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var invitation = await dbContext.OrganizationInvitaions.FindAsync(Id);
        return invitation;
    }
    public async Task Create(ClaimsPrincipal userClaims, string email)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var user = await dbContext.Users
            .Where(x => x.Id == userClaims.GetUserId())
            .Include(x => x.ActiveOrganization)
            .FirstOrDefaultAsync();
        if (user?.ActiveOrganization is null)
        {
            logger.LogWarning("{User} has no active organization", user);
            return;
        }
        var invitation = new OrganizationInvitaion
        {
            Email = email,
            OrganizationId = user.ActiveOrganization.Id
        };
        invitation.OrganizationId = user.ActiveOrganization.Id;
        await dbContext.OrganizationInvitaions.AddAsync(invitation);
        await dbContext.SaveChangesAsync();
        await emailService.SendAsync(
            "noreply@companion.com", 
            invitation.Email, 
            "Invitation to join organization",
            $""""""<h4> You have been invited to join <a href="{navigationManager.BaseUri}{ApplicationRoutes.InvitationConfirmation.Replace("/", string.Empty)}/{invitation.Id}">{user.ActiveOrganization.Name}</a></h4>"""""",
            true);
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
