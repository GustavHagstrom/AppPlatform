﻿using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using SharedPlatformLibrary.HttpRequests;
using System.Security.Claims;

namespace License.Api.Features.Claims;
public class ClaimService : IClaimService
{
    private readonly LicenseDbContext _dbContext;

    public ClaimService(LicenseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public  async Task<ICollection<ClaimModel>> GetCustomClaims(ClaimsRequestBody claimsRequestBody)
    {
        var user = await _dbContext.Users
            .Where(x => x.Id == claimsRequestBody.UserId)
            .Include(x => x.Roles)
            .Include(x => x.Organizations)
            .Include(x => x.Licenses)
            .FirstOrDefaultAsync();

        var claims = new List<ClaimModel>();
        if (user is not null)
        {
            var roles = user.Roles
                .Select(x => new ClaimModel(ClaimTypes.Role, x.Name));
            var orgs = user.Organizations
                .Select(x => new ClaimModel(CustomClaimTypes.OrganizationMemberOf, x.Id.ToString()));
            var licenses = user.Licenses
                .Where(x => x.OrganizationId == user.CurrentOrganizationId && x.ApplicationName == claimsRequestBody.ApplicationName) 
                .Select(x => new ClaimModel(CustomClaimTypes.License, x.Id.ToString()));

            var currentOrgId = user.CurrentOrganizationId.ToString();
            if (currentOrgId is not null)
            {
                claims.Add(new ClaimModel(CustomClaimTypes.CurrentOrganization, currentOrgId));
            }
            claims.AddRange(roles);
            claims.AddRange(orgs);
            claims.AddRange(licenses);
        }
        return claims;
    }
}