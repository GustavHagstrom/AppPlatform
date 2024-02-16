using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace AppPlatform.Shared.Services.Authorization;
public class AccessClaimService(IDbContextFactory<ApplicationDbContext> DbContextFactory, ILogger<AccessClaimService> logger) : IAccessClaimService
{
    public async Task<IEnumerable<AccessClaim>> GetAccessClaims(ClaimsPrincipal? userClaims)
    {
        //ArgumentNullException.ThrowIfNull(userClaims); //Bad?? Maybe not necessary
        var userId = userClaims?.GetUserId();
        var tenantId = userClaims?.GetTenantId();
        if (userId == null || tenantId == null)
        {
            logger.LogWarning("User or tenant id is null");
            return Enumerable.Empty<AccessClaim>();
        }

        using var context = DbContextFactory.CreateDbContext();
        var userRoles = await context.UserRoles
            .Include(ur => ur.Role)
            .ThenInclude(r => r!.RoleAccesses)
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
        var userAccesses = await context.UserAccess.Where(ua => ua.UserId == userId).ToListAsync();

        var values = userRoles
            .Select(ur => ur.Role)
            .SelectMany(r => r.RoleAccesses)
            .Select(ra => ra.AccessId)
            .Concat(userAccesses.Select(ua => ua.AccessId));

        HashSet<string> claimValues = new(values);
        return claimValues.Select(claimValue => new AccessClaim(claimValue));

    }
}
