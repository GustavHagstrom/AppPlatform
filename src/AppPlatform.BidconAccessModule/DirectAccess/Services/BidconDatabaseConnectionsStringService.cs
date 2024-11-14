using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Services;
public class BidconDatabaseConnectionsStringService(IDbContextFactory<ApplicationDbContext> DbContextFactory) : IBidconDbConnectionstringService
{
    public async Task<string> BuildAsync(ClaimsPrincipal userClaims)
    {
        var context = await DbContextFactory.CreateDbContextAsync();
        var credentials = await context.BidconAccessCredentials.Where(x => x.TenantId == userClaims.GetTenantId()).FirstOrDefaultAsync();

        if (credentials == null)
        {
            throw new Exception("No credentials found for user");
        }

        return credentials.ServerAuthentication
            ? $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;uid={credentials.User};pwd={credentials.Password};TrustServerCertificate=True"
            : $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;Integrated security=true;TrustServerCertificate=True;Encrypt=False;Multi Subnet Failover=False";
    }
}
