using Server.Data;
using Server.Enteties;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace Server.Middlewares;

public class LazyUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LazyUserMiddleware> _logger;

    /// <summary>
    /// This needs to be after LazyOrganizationMiddleware in the pipeline
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public LazyUserMiddleware(RequestDelegate next, ILogger<LazyUserMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            var scope = context.Items[MiddlewareItemKeyConstants.SharedScope] as IServiceScope;
            ArgumentNullException.ThrowIfNull(scope);

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var userId = context.User.FindFirstValue(ClaimConstants.ObjectId);
            var organizationId = context.User.FindFirstValue(ClaimConstants.TenantId);

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(organizationId))
            {
                var user = await dbContext.Users.FindAsync(userId);
                if (user is null)
                {
                    _logger.LogInformation("User was not found in database. Inserting new");
                    await dbContext.Users.AddAsync(new User
                    {
                        Id = userId,
                        OrganizationId = organizationId,
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error in LazyUserMiddleware");
        }
        await _next(context);
    }
}
