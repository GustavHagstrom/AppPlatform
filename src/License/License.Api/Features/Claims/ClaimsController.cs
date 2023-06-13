using Microsoft.AspNetCore.Mvc;
using SharedPlatformLibrary.HttpRequests;

namespace License.Api.Features.Claims;
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly IClaimService _claimService;
    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(IClaimService claimService, ILogger<ClaimsController> logger)
    {
        _claimService = claimService;
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> Get([FromBody] ClaimsRequestBody claimsRequestBody)
    {
        try
        {
            return Ok(await _claimService.GetCustomClaims(claimsRequestBody));
        }
        catch (ArgumentNullException e)
        {
            _logger.LogWarning(e, "userId or organization name might be null");
            return Problem("UserId might be null");
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Unexpected exception when getting custom claims");
            return Problem("Unexpected exception when getting custom claims");
        }
    }
}
