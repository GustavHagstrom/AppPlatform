using Microsoft.EntityFrameworkCore;
using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties;
using AppPlatform.Core.Extensions;
using System.Security.Claims;

namespace AppPlatform.Core.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public OrganizationService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    public async Task<IEnumerable<Organization>> GetAllAsync(ClaimsPrincipal userClaims)
    {
        var dbContext = _contextFactory.CreateDbContext();
        var organizations = await dbContext.UserOrganizations
            .Include(x => x.Organization)
            .Where(x => x.UserId == userClaims.GetUserId())
            .ToListAsync();
        return organizations.Select(x => x.Organization!);

    }
    public async Task<string?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims)
    {
        var dbContext = _contextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        return user?.ActiveOrganizationId;
    }
    public async Task SetActiveAsync(ClaimsPrincipal userClaims, Organization? organization)
    {
        await ExecuteIfUserIsNotNull(userClaims, async (user, dbContext) =>
        {
            user.ActiveOrganizationId = organization?.Id;
            await dbContext.SaveChangesAsync();
        });
    }

    public async Task CreateAsync(ClaimsPrincipal userClaims, Organization organization)
    {
        await ExecuteIfUserIsNotNull(userClaims, async (user, dbContext) =>
        {
            dbContext.Organizations.Add(organization);
            dbContext.UserOrganizations.Add(new UserOrganization
            {
                OrganizationId = organization.Id,
                UserId = user.Id
            });
            user.ActiveOrganizationId = organization.Id;
            await dbContext.SaveChangesAsync();
        });
    }
 public async Task UpdateAsync(ClaimsPrincipal userClaims, Organization organization)
    {
        await ExecuteIfUserIsNotNull(userClaims, async (user, dbContext) =>
        {
            var org = await dbContext.Organizations.FindAsync(organization.Id);
            if(org is not null)
            {
                org.Name = organization.Name;
                await dbContext.SaveChangesAsync();
            }
        });
    }
    private async Task ExecuteIfUserIsNotNull(ClaimsPrincipal userClaims, Func<User, ApplicationDbContext, Task> action)
    {
        if (userClaims.Identity?.IsAuthenticated == false) return;
        var dbContext = _contextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user is not null)
        {
            await action(user, dbContext);
        }
    }

   
}
