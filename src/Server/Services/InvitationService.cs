using Microsoft.EntityFrameworkCore;
using AppPlatform.Server.Data;
using AppPlatform.Server.Enteties;
using System.Security.Claims;
using AppPlatform.Server.Extensions;
using AppPlatform.Server.Services.Email;
using AppPlatform.Shared.Constants;
using Microsoft.AspNetCore.Components;
using static AppPlatform.Server.Enteties.OrganizationInvitaion;

namespace AppPlatform.Server.Services;

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
    public async Task SendAsync(ClaimsPrincipal userClaims, string email)
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
            OrganizationId = user.ActiveOrganization.Id,
            Status = InvitationStatus.Pending,
        };
        await dbContext.OrganizationInvitaions.AddAsync(invitation);
        await dbContext.SaveChangesAsync();
        var link = $"{navigationManager.BaseUri}{ApplicationRoutes.InvitationConfirmation.Replace("/", string.Empty)}/{invitation.Id}";
        var subject = "Organization invitation";
        var body = $@"<h4>You have been invited to join the organization ""{user.ActiveOrganization.Name}"".</h4><p>To accept follow this link: <a href=""{link}"">{link}</a></p>";
        var isBodyHtml = true;
        await emailService.SendAsync(email, subject, body, isBodyHtml);
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
    public async Task AcceptInvitaionAsync(ClaimsPrincipal userClaims, OrganizationInvitaion invitation)
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
            OrganizationId = invitation.OrganizationId,
            UserId = user.Id
        };
        invitation.Status = InvitationStatus.Accepted;
        dbContext.Attach(invitation);
        dbContext.OrganizationInvitaions.Update(invitation);

        user.ActiveOrganizationId = invitation.OrganizationId;
        dbContext.Users.Update(user);
        dbContext.UserOrganizations.Add(userOrg);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrganizationInvitaion>> GetAllAsync(Organization organization)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var invitations = await dbContext.OrganizationInvitaions
            .Where(x => x.OrganizationId == organization.Id)
            .ToListAsync();
        return invitations;
    }
}
