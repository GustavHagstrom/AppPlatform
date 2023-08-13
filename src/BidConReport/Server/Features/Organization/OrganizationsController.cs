using BidConReport.Server.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace BidConReport.Server.Features.Organization;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        return Ok(await _organizationService.GetAll(userId));
    }
    [HttpGet("Current")]
    public async Task<IActionResult> GetCurrent()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        return Ok(await _organizationService.GetCurrent(userId));
    }
    [HttpPost("SetAsCurrent")]
    public async Task<IActionResult> SetAsCurrent([FromBody] SharedPlatformLibrary.Enteties.Organization organization)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        await _organizationService.SetAsActive(userId, organization);
        return Ok();
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] SharedPlatformLibrary.Enteties.Organization organization)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        await _organizationService.CreateNew(userId, organization);
        await _organizationService.SetAsActive(userId, organization);
        return Ok();
    }
}
