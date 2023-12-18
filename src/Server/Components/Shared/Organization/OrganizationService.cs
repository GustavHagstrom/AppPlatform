using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Enteties;
using Server.Extensions;
using System.Security.Claims;

namespace Server.Components.Shared.Organization;

public class OrganizationService : IOrganizationService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly SignInManager<User> _signInManager;

    public OrganizationService(ApplicationDbContext DbContext, SignInManager<User> SignInManager)
    {
        _dbContext = DbContext;
        _signInManager = SignInManager;
    }
    public async Task<IEnumerable<Enteties.Organization>> GetAllAsync(ClaimsPrincipal userClaims)
    {
        var organizations = await _dbContext.UserOrganizations
            .Include(x => x.Organization)
            .Where(x => x.UserId == userClaims.GetUserId())
            .ToListAsync();
        return organizations.Select(x => x.Organization!);

    }
    public async Task<Guid?> GetActiveOrgIdAsync(ClaimsPrincipal userClaims)
    {
        var user = await _dbContext.Users.FindAsync(userClaims.GetUserId());
        return user?.ActiveOrganizationId;
    }
    public async Task SetActiveAsync(ClaimsPrincipal userClaims, Enteties.Organization organization)
    {
        var user = await _dbContext.Users.FindAsync(userClaims.GetUserId());
        if (user is not null)
        {
            user.ActiveOrganizationId = organization.Id;
            await _dbContext.SaveChangesAsync();
            await _signInManager.RefreshSignInAsync(user);
        }
    }
}
