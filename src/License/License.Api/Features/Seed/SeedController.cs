using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Enteties;
using System.Linq;

namespace License.Api.Features.Seed;
[Route("api/[controller]")]
[ApiController]
public class SeedController : ControllerBase
{
    private readonly ISeedService _seedService;
    private readonly ILogger<SeedController> _logger;

    public SeedController(ISeedService seedService, ILogger<SeedController> logger)
    {
        _seedService = seedService;
        _logger = logger;
    }
    [HttpPost("AppSeed")]
    public async Task<IActionResult> AppSeed([FromBody] AppSeedModel seedModel)
    {
        try
        {
            await _seedService.SeedAplicationDataAsync(seedModel);
            return Ok();
        }
        catch (Exception e)
        {
            string message = $"Exception during database seed from application: {seedModel.ApplicationName}";
            _logger.LogCritical(e, message);
            return Problem(message);
        }
    }
}
