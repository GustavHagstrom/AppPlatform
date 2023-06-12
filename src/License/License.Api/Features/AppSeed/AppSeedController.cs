using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Enteties;
using System.Linq;

namespace License.Api.Features.AppSeed;
[Route("api/[controller]")]
[ApiController]
public class AppSeedController : ControllerBase
{
    private readonly IAppSeedService _seedService;
    private readonly ILogger<AppSeedController> _logger;

    public AppSeedController(IAppSeedService seedService, ILogger<AppSeedController> logger)
    {
        _seedService = seedService;
        _logger = logger;
    }
    [HttpPost]
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
