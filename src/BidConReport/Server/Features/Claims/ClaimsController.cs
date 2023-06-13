using BidConReport.Server.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Net.Http.Headers;

namespace BidConReport.Server.Features.Claims;
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly IClaimsProvider _claimsProvider;
    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(IClaimsProvider claimsProvider, ILogger<ClaimsController> logger)
    {
        _claimsProvider = claimsProvider;
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> GetClaims(CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.Claims
                .Where(x => x.Type == ClaimConstants.ObjectId)
                .Select(x => x.Value)
                .FirstOrDefault();
            ArgumentNullException.ThrowIfNull(userId);
            var result = await _claimsProvider.GetClaimsAsync(userId);
            return Ok(result);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, "UserId may be null");
            throw;
        }
        catch (Exception)
        {

            throw;
        }
    }
}