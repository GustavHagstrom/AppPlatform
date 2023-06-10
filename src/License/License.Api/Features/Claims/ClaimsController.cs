using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

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
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string applicationName)
    {
        try
        {
            var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).Select(x => x.Value).FirstOrDefault();
            ArgumentNullException.ThrowIfNull(userId);
            return Ok(await _claimService.GetCustomClaims(userId, applicationName));
        }
        catch (ArgumentNullException e)
        {
            _logger.LogWarning(e, "userId might be null");
            return Problem("UserId might be null");
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Unexpected exception when getting custom claims");
            return Problem("Unexpected exception when getting custom claims");
        }
    }
}
