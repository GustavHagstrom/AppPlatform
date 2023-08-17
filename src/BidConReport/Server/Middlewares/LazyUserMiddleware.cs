using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using BidConReport.Server.Services.Authentication;
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
        var claimsProvider = scope.ServiceProvider.GetRequiredService<IClaimsService>();
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
        var orgStringResult = context.User.Claims
            .Where(x => x.Type == CustomClaimTypes.CurrentOrganization)
            .Select(x => x.Value)
            .FirstOrDefault();
        var organizationId = int.TryParse(orgStringResult, out int tempVal) ? tempVal : 0;
        if (userId is not null)
        {
            await AddNewUserToDbIfNeeded(userId, dbContext);
        }
        if (userId is not null && organizationId != 0)
        {
            await AddUnlistedUserOrgIfNeeded(userId, organizationId, dbContext);
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
    private async Task AddUnlistedUserOrgIfNeeded(string userId, int organizationId, ApplicationDbContext dbContext)
    {
        var userOrganization = await dbContext.UserOrganizations
            .Where(x => x.UserId == userId && x.OrganizationId == organizationId)
            .Select(x => x.OrganizationId)
            .FirstOrDefaultAsync();
        if (userOrganization == 0)
        {
            _logger.LogInformation("Adding missing userOrganization");
            await dbContext.UserOrganizations.AddAsync(new UserOrganization
            {
                UserId = userId,
                OrganizationId = organizationId,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
