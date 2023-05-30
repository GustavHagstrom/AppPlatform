using Collie.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Collie.Server.Features.Test;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("Claims")]
    public IActionResult GetClaims(CancellationToken cancellationToken)
    {
        var claimsStrings = new List<ClaimStrings>();
        foreach (var claim in User.Claims)
        {
            claimsStrings.Add(new ClaimStrings { Type = claim.Type, Value = claim.Value });
        }
        return Ok(claimsStrings);
    }
}
