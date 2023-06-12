using License.Api.Shared.Enteties;
using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Enteties;
using System.Runtime.CompilerServices;

namespace License.Api.Features.AppSeed;
public class AppSeedService : IAppSeedService
{
    private readonly LicenseDbContext _dbContext;

    public AppSeedService(LicenseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SeedAplicationDataAsync(AppSeedModel seedModel)
    {
        var application = await _dbContext.Applications.Where(x => x.Name == seedModel.ApplicationName).FirstOrDefaultAsync();
        bool changesMade = false;
        if (application is null)
        {
            await _dbContext.Applications.AddAsync(new Application { Name = seedModel.ApplicationName });
            changesMade = true;
        }
        List<Role> roles = await _dbContext.Roles.Where(x => x.Name == seedModel.ApplicationName).ToListAsync();
        var roleNames = roles.Select(x => x.Name).ToArray();
        foreach (var roleName in seedModel.Roles)
        {
            if (!roleNames.Contains(roleName))
            {
                await _dbContext.Roles.AddAsync(new Role { ApplicationName = seedModel.ApplicationName, Name = roleName });
                changesMade = true;
            }
        }
        if (changesMade)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
