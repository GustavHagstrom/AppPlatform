﻿using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using AppPlatform.Shared.Models;
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
        if (userId == null)
        {
            logger.LogWarning("User id is null");
            return Enumerable.Empty<AccessClaim>();
        }

        return await GetAccessClaims(userId);

    }

    public async Task<IEnumerable<AccessClaim>> GetAccessClaims(string userId)
    {
        using var context = DbContextFactory.CreateDbContext();
        var userRoles = await context.UserRoles
            .Include(ur => ur.Role)
            .ThenInclude(r => r!.RoleAccesses)
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
        var userAccesses = await context.UserAccess.Where(ua => ua.UserId == userId).ToListAsync();

        var values = userRoles
            .Select(ur => ur.Role)
            .Where(r => r is not null)
            .SelectMany(r => r!.RoleAccesses)
            .Select(ra => ra.AccessClaimValue)
            .Concat(userAccesses.Select(ua => ua.AccessClaimValue));

        HashSet<string> claimValues = new(values);
        return claimValues.Select(claimValue => new AccessClaim(claimValue));
    }
}
