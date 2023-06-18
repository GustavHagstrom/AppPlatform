using BidConReport.Server.Data;
using BidConReport.Server.Shared.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.Enteties;
using System.Net.Http.Headers;

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
                .Select(x => new ClaimModel(x.Type, x.Value))
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