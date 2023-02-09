using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SharedLibrary;
public static class WebApplicaitonExtensions
{
    private static HttpClient? _httpClient;
    //private static HttpRequestMessage? _getGroupsRequest;
    public static void UseSharedLibraryMiddleware(this WebApplication app)
    {
        _httpClient = app.Services.GetRequiredService<IHttpClientFactory>().CreateClient("Middleware");
        //_getGroupsRequest = new HttpRequestMessage(HttpMethod.Get, "/me/transitiveMemberOf/microsoft.graph.group?$count=true");
        app.Use(AddGroupsAsClaims);
    }

    private static async Task AddGroupsAsClaims(HttpContext context, RequestDelegate next)
    {
        if (context.User?.Identity?.IsAuthenticated == true)
        {
            var groups = await GetGroupsForUser(context);
            foreach (var group in groups)
            {
                ((ClaimsIdentity)context.User.Identity).AddClaim(new Claim("groups", group));
            }
        }
        await next(context);
    }
    private static async Task<IEnumerable<string>> GetGroupsForUser(HttpContext context)
    {
        var authHeader = context.Request.Headers.Authorization.ToString();
        var request = new HttpRequestMessage(HttpMethod.Get, "/me/transitiveMemberOf/microsoft.graph.group?$count=true");
        if (authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring(7);// Skip(7).ToArray();
            request.Headers.Add("Bearer", token);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authHeader.Substring(7, authHeader.Length));
        }
        List<string> groups = new();
        var response = await _httpClient!.SendAsync(request);
        if(response.IsSuccessStatusCode)
        {
            
        }
        return groups;
    }
}
