using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace BidConReport.Server.Features.DarkMode;

[Route("api/[controller]")]
[ApiController]
public class DarkModeController : ControllerBase
{
    private readonly IDarkModeService _darkModeService;

    public DarkModeController(IDarkModeService darkModeService)
    {
        _darkModeService = darkModeService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        return Ok(await _darkModeService.GetUserDarkModeSettingAsync(userId));
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody ]string isDarkMode)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        await _darkModeService.SetUserDarkModeSettingAsync(userId, bool.Parse(isDarkMode));
        return Ok();
    }
}
