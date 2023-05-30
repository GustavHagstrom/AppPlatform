using Microsoft.AspNetCore.Mvc;

namespace Collie.Server.Features.Authorization;
[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{

    [HttpGet("Claims")]
    public IActionResult GetClaims(CancellationToken cancellationToken)
    {
        var claims = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("ClaimType1", "Value1"),
            new KeyValuePair<string, string>("ClaimType2", "Value2")
        };
        return Ok(claims);
    }
}
