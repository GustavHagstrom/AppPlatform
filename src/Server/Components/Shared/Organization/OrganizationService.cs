using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using Server.Extensions;
using System.Security.Claims;

namespace Server.Components.Shared.Organization;

public class OrganizationService : IOrganizationService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    private readonly SignInManager<User> _signInManager;

    public OrganizationService(IDbContextFactory<ApplicationDbContext> contextFactory, SignInManager<User> signInManager)
    {
        _contextFactory = contextFactory;
        _signInManager = signInManager;
    }
    public async Task<IEnumerable<Enteties.Organization>> GetAllAsync(ClaimsPrincipal userClaims)
    {
        var dbContext = _contextFactory.CreateDbContext();
        var organizations = await dbContext.UserOrganizations
            .Include(x => x.Organization)
            .Where(x => x.UserId == userClaims.GetUserId())
            .ToListAsync();
        return organizations.Select(x => x.Organization!);

    }
    public async Task<Guid?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims)
    {
        var dbContext = _contextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        return user?.ActiveOrganizationId;
    }
    public async Task SetActiveAsync(ClaimsPrincipal userClaims, Enteties.Organization organization)
    {
        var dbContext = _contextFactory.CreateDbContext();
        var user = await dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user is not null)
        {
            user.ActiveOrganizationId = organization.Id;
            await dbContext.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
        }
    }
}
