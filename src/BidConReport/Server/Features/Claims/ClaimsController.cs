using BidConReport.Server.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BidConReport.Server.Features.Claims;
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly IClaimsProvider _claimsProvider;

    public ClaimsController(IClaimsProvider claimsProvider)
    {
        _claimsProvider = claimsProvider;
    }
    [HttpGet]
    public async Task<IActionResult> GetClaims(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _claimsProvider.GetClaimsAsync();
            return Ok(result);
        }
        catch (Exception)
        {

            throw;
        }
    }
}