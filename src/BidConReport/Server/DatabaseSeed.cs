using BidConReport.Server.Data;
using BidConReport.Server.Features.Authorization.Models;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server;

public static class DatabaseSeed
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //context.Database.EnsureCreated();
            //context.Database.Migrate();
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
            if(changesMade)
            {
                context.SaveChanges();
            }
        }
    }
}
