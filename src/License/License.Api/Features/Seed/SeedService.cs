using License.Api.Shared.Enteties;
using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Enteties;
using System.Runtime.CompilerServices;

namespace License.Api.Features.Seed;
public class SeedService : ISeedService
{
    private readonly LicenseDbContext _dbContext;

    public SeedService(LicenseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SeedAplicationDataAsync(AppSeedModel seedModel)
    {
        await _dbContext.Database.EnsureCreatedAsync();
        await EnsureMigratedAsync();
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
    private async Task EnsureMigratedAsync()
    {
        var appliedMigrations = await _dbContext.Database.GetAppliedMigrationsAsync();
        var allMigrations = _dbContext.Database.GetMigrations();
        if (allMigrations.Except(appliedMigrations).Any())
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}
