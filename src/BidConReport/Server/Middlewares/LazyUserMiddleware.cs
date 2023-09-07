using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using BidConReport.Server.Services.Authentication;
using Microsoft.Identity.Web;
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
        var userId = context.User.FindFirstValue(ClaimConstants.ObjectId);
        var organizationId = context.User.FindFirstValue(ClaimConstants.TenantId);

        if (organizationId is not null)
        {
            await AddUnlistedUserOrgIfNeeded(organizationId, dbContext);
        }
        if (userId is not null && organizationId is not null)
        {
            await AddNewUserToDbIfNeeded(userId, organizationId, dbContext);
        }
    }
    private async Task AddNewUserToDbIfNeeded(string userId, string organizationId, ApplicationDbContext dbContext)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null)
        {
            _logger.LogInformation("User was not found in DB. Creating new user");
            await dbContext.Users.AddAsync(new User
            {
                Id = userId,
                OrganizationId = organizationId,
            });
            await dbContext.SaveChangesAsync();
        }
    }
    private async Task AddUnlistedUserOrgIfNeeded(string organizationId, ApplicationDbContext dbContext)
    {
        var userOrganization = await dbContext.Organizations.FindAsync(organizationId);
        if (userOrganization is null)
        {
            _logger.LogInformation("Adding missing userOrganization");
            await dbContext.Organizations.AddAsync(new Organization
            {
                Id = organizationId,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
