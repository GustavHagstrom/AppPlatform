using Microsoft.EntityFrameworkCore;
using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties;

namespace AppPlatform.Server.Components.Features.Settings.OrganizationSettings;

public class UserListService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
{
    public async Task<IEnumerable<User>> GetUsersAsync(Organization organization)
    {
        var dbContext = dbContextFactory.CreateDbContext();
        var users = await dbContext.Users
            .Where(u => u.UserOrganizations.Any(uo => uo.OrganizationId == organization.Id))
            .ToListAsync();
        return users;
    }
}
