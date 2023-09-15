namespace Server.Middlewares;

public class ScopeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceProvider _serviceProvider;

    public ScopeMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
    {
        _next = next;
        _serviceProvider = serviceProvider;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Create a scope and make it available to downstream middlewares.
        using (var scope = _serviceProvider.CreateScope())
        {
            // Register the scope as a request service.
            context.Items[MiddlewareItemKeyConstants.SharedScope] = scope;

            // Continue processing the request.
            await _next(context);
        }
    }
}
