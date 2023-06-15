using BidConReport.Server.Data;
using BidConReport.Server.Shared.Enteties;
using Microsoft.Identity.Web;

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
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userId = context.User.Claims.Where(x => x.Type == ClaimConstants.TenantId).FirstOrDefault()?.Value;
                if (userId is not null)
                {
                    var user = await dbContext.Users.FindAsync(userId);
                    if (user == null)
                    {
                        _logger.LogInformation("User was not found in DB. Creating new user");
                        await AddNewUserToDb(userId, dbContext);
                    }
                }
                await _next.Invoke(context);
            }
            
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Error in lazyusermiddleware");
        }
        
    }
    private async Task AddNewUserToDb(string userId, ApplicationDbContext dbContext)
    {
        await dbContext.Users.AddAsync(new User
        {
            Id = userId
        });
        await dbContext.SaveChangesAsync();
    }
}
