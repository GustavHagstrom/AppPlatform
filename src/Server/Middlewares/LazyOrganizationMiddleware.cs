using Server.Data;
using Server.Enteties;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace Server.Middlewares;

public class LazyOrganizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LazyOrganizationMiddleware> _logger;

    /// <summary>
    /// This needs to be placed before LazyOrganizationMiddleware in the pipeline
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public LazyOrganizationMiddleware(RequestDelegate next, ILogger<LazyOrganizationMiddleware> logger)
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

            var organizationId = context.User.FindFirstValue(ClaimConstants.TenantId);
            if (!string.IsNullOrEmpty(organizationId))
            {
                var organization = await dbContext.Organizations.FindAsync(organizationId);
                if (organization is null)
                {
                    _logger.LogInformation("Organization was not found in database. Inserting new");
                    await dbContext.Organizations.AddAsync(new Organization
                    {
                        Id = organizationId,
                    });
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        catch (Exception e)
        {
            _logger.LogCritical(e, "Error in LazyOrganizationMiddleware");
        }
        await _next(context);
    }
}
