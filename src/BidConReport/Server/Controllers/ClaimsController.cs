using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.Server.Controllers;
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
            var customTypes = ApplicationClaimConstants.GetAllTypesAsCollection();
            var claims = User.Claims
                .Where(x => customTypes.Contains(x.Type))
                .Select(x => new ClaimDto(x.Type, x.Value))
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