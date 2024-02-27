using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Services;
using AppPlatform.Shared.Services.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AppPlatform.UserRightSettingsModule.Services;
internal class UserAccessService : IUserAccessService
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly IAccessClaimInfoContainer _accessClaimInfoContainer;

    public UserAccessService(IDbContextFactory<ApplicationDbContext> dbContextFactory, IAccessClaimInfoContainer accessClaimInfoContainer)
    {
        _dbContextFactory = dbContextFactory;
        _accessClaimInfoContainer = accessClaimInfoContainer;
    }
    public async Task<IEnumerable<IAccessClaimInfo>> GetAccessClaims(string userId)
    {
        using var context = _dbContextFactory.CreateDbContext();
        var userAccesses = await context.UserAccess
            .Where(ua => ua.UserId == userId)
            .ToListAsync();

        var accessInfos = _accessClaimInfoContainer.AccessClaimInfos
            .Where(x => userAccesses.Any(ua => ua.AccessClaimValue == x.Value));

        return accessInfos;
    }
}
