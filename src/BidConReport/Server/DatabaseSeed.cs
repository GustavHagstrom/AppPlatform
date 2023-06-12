using BidConReport.Server.Data;
using BidConReport.Server.Features.Authorization.Models;
using BidConReport.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server;

public static class DatabaseSeed
{
    public static void EnsureSeedData(WebApplication app)
    {
        //Should be logged
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            SeedApplicationDb(scope);
            SeedLicenseDb(scope);
        }
    }
    private static void SeedApplicationDb(IServiceScope scope)
    {
        //Should be logged
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roles = context.Roles.Where(r => true).ToArray();
        var requiredRoles = new string[] { "admin", "creator" };
        var changesMade = false;
        foreach (var requiredRole in requiredRoles)
        {
            if (!roles.Select(r => r.Name).Contains(requiredRole))
            {
                changesMade = true;
                context.Roles.Add(new Role { Name = requiredRole });
            }
        }
        if (changesMade)
        {
            context.SaveChanges();
        }
    }
    private static void SeedLicenseDb(IServiceScope scope)
    {
        //Should be logged
        var licenseClient = scope.ServiceProvider.GetRequiredService<HttpClient>();
        var seedModel = new AppSeedModel
        {
            ApplicationName = CommonConstants.ApplicationName,
            Roles = CommonConstants.AppRoles,
        };
        var result = licenseClient.PostAsJsonAsync(LicenseApiEndpoints.ApplicationSeed, seedModel).Result;
    }
}
