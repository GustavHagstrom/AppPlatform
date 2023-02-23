using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Graph;
using System.Security.Claims;

namespace BidConReport.Client.Features.Authentication;

public class MsGraphAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly GraphServiceClient _graphServiceClient;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MsGraphAuthenticationStateProvider(GraphServiceClient graphServiceClient, IHttpContextAccessor httpContextAccessor)
    {
        _graphServiceClient = graphServiceClient;
        _httpContextAccessor = httpContextAccessor;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Get the current HttpContext
        var httpContext = _httpContextAccessor.HttpContext;

        // Get the current authentication state from the HttpContext
        var authState = await httpContext.AuthenticateAsync();

        var user = authState.Principal;

        // Retrieve user's claims from Microsoft Graph
        var graphUser = await _graphServiceClient.Me.Request().GetAsync();
        //var identity = (ClaimsIdentity)user.Identity!;

        if(user.Identity is not null && user.Identity.IsAuthenticated && user.Identity is ClaimsIdentity identity)
        {
            var photoString = await GetPhotoStringAsync();
            identity.AddClaim(new Claim("photo", photoString));
        }
        return new AuthenticationState(user);
    }

    private async Task<string> GetPhotoStringAsync()
    {
        // Retrieve user's claims from Microsoft Graph
        var photo = await _graphServiceClient.Me.Photo.Request().GetAsync();
        if (!photo.AdditionalData.ContainsKey("error"))
        {
            var ms = new MemoryStream();
            var photoStream = await _graphServiceClient.Me.Photo.Content.Request().GetAsync();
            photoStream.CopyTo(ms);
            var photoBytes = ms.ToArray();
            var photoBase64 = Convert.ToBase64String(photoBytes);
            return $"data:image/png;base64,{photoBase64}";
        }
        return string.Empty;
    }
}
