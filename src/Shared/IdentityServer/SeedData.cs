using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServer;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        Log.Warning("Seeding database...");        
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var role = roleMgr.FindByNameAsync("OrganizationAdmin").Result;
            if (role is null)
            {
                var result = roleMgr.CreateAsync(new IdentityRole { Name = "OrganizationAdmin" }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("""Role "OrganizationAdmin" created""");
            }
            else
            {
                Log.Debug("""Role "OrganizationAdmin" already exists""");
            }
        }
        Log.Information("Done seeding database. Exiting.");
    }
}
