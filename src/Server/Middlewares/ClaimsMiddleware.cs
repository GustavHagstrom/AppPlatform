//using Server.Services.Authentication;
//using System.Security.Claims;

//namespace Server.Middlewares;

//public class ClaimsMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly ILogger<ClaimsMiddleware> _logger;

//    public ClaimsMiddleware(RequestDelegate next, ILogger<ClaimsMiddleware> logger)
//    {
//        _next = next;
//        _logger = logger;
//    }
//    public async Task InvokeAsync(HttpContext context)
//    {
//        try
//        {
//            var scope = context.Items[MiddlewareItemKeyConstants.SharedScope] as IServiceScope;
//            ArgumentNullException.ThrowIfNull(scope);

//            var claimsProvider = scope.ServiceProvider.GetRequiredService<IClaimsService>();
            
//            var userId = context.User.FindFirst(ClaimConstants.ObjectId)?.Value;
//            if(!string.IsNullOrEmpty(userId) )
//            {
//                var customClaims = await claimsProvider.GetClaimsAsync(userId);
//                var identidy = context.User.Identity as ClaimsIdentity;
//                identidy?.AddClaims(customClaims.Select(x => new Claim(x.Type, x.Value)));
//            }
//        }

//        catch (Exception e)
//        {
//            _logger.LogCritical(e, "Error in ClaimsMiddleware");
//        }

//        await _next(context);
//    }
//}
