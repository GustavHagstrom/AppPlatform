using Microsoft.AspNetCore.Mvc;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Features.Claims;
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly ILogger<ClaimsController> _logger;

    public ClaimsController(ILogger<ClaimsController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var customTypes = CustomClaimTypes.GetAllTypesAsCollection();
            var claims = User.Claims
                .Where(x => customTypes.Contains(x.Type))
                .Select(x => new ClaimDTO(x.Type, x.Value))
                .ToArray();
            _logger.LogInformation("returning claims from server");
            return Ok(claims);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected error when getting claims");
            throw;
        }
    }
}