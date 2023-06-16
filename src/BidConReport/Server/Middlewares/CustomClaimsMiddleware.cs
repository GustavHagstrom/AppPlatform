using BidConReport.Server.Shared.Services;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace BidConReport.Server.Middlewares;

public class CustomClaimsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public CustomClaimsMiddleware(RequestDelegate next, IServiceProvider serviceProvider, ILogger<CustomClaimsMiddleware> logger)
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
                var claimsProvider = scope.ServiceProvider.GetRequiredService<IClaimsProvider>();
                var userId = context.User.Claims.Where(x => x.Type == ClaimConstants.TenantId).FirstOrDefault()?.Value;
                if (userId is not null)
                {
                    var customClaims = await claimsProvider.GetClaimsAsync(userId);
                    var identidy = context.User.Identity as ClaimsIdentity;
                    identidy?.AddClaims(customClaims.Select(x => new Claim(x.Type, x.Value)));
                }
            }

        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error in CustomClaimsMiddleware");
        }
        await _next.Invoke(context);
    }
   
}
