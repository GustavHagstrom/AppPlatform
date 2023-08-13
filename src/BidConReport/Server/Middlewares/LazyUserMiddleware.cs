using BidConReport.Server.Data;
using BidConReport.Server.Shared.Enteties;
using BidConReport.Server.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;
using System.Diagnostics;
using System.Security.Claims;

namespace BidConReport.Server.Middlewares;

public class LazyUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public LazyUserMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<LazyUserMiddleware> logger)
    {
        _next = next;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                await SetUserClaims(scope, context);
                await LazyUser(scope, context);
            }
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error in lazyusermiddleware");
        }
        await _next.Invoke(context);
    }
    private async Task SetUserClaims(IServiceScope scope, HttpContext context)
    {
        var claimsProvider = scope.ServiceProvider.GetRequiredService<IClaimsProvider>();
        var userId = context.User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        if (userId is not null)
        {
            var customClaims = await claimsProvider.GetClaimsAsync(userId);
            var identidy = context.User.Identity as ClaimsIdentity;
            identidy?.AddClaims(customClaims.Select(x => new Claim(x.Type, x.Value)));
        }
    }
    private async Task LazyUser(IServiceScope scope, HttpContext context)
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userId = context.User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var organizationIds = context.User.Claims
            .Where(x => x.Type == CustomClaimTypes.OrganizationMemberOf)
            .Select(x => x.Value)
            .ToArray();
        if (userId is not null)
        {
            await AddNewUserToDbIfNeeded(userId, dbContext);
        }
        if (userId is not null && organizationIds is not null)
        {
            await AddUnlistedUserOrgsIfNeeded(userId, organizationIds, dbContext);
        }
    }
    private async Task AddNewUserToDbIfNeeded(string userId, ApplicationDbContext dbContext)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            _logger.LogInformation("User was not found in DB. Creating new user");
            await dbContext.Users.AddAsync(new User
            {
                Id = userId
            });
            await dbContext.SaveChangesAsync();
        }
        
    }
    private async Task AddUnlistedUserOrgsIfNeeded(string userId, ICollection<string> organizationIds, ApplicationDbContext dbContext)
    {
        var userOrganizations = await dbContext.UserOrganizations
            .Where(x => x.UserId == userId)
            .Select(x => x.OrganizationId)
            .ToListAsync();
        var unlistedUserOrgs = new List<UserOrganization>();
        bool addRecords = false;
        foreach (var id in organizationIds)
        {
            if (!userOrganizations.Contains(id))
            {
                addRecords = true;
                unlistedUserOrgs.Add(new UserOrganization
                {
                    UserId = userId,
                    OrganizationId = id,
                });
            }
        }

        if (addRecords)
        {
            _logger.LogInformation("Adding userOrganizations");
            await dbContext.UserOrganizations.AddRangeAsync(unlistedUserOrgs);
            await dbContext.SaveChangesAsync();
        }
    }
}
