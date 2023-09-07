using BidConReport.Server.Services;
using BidConReport.Shared.DTOs.BidconAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace BidConReport.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BidconCredentialsController : ControllerBase
{
    private readonly IBidconCredentialsService _bidconCredentialsService;

    public BidconCredentialsController(IBidconCredentialsService bidconCredentialsService)
    {
        _bidconCredentialsService = bidconCredentialsService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
        if (organizationId is null)
        {
            return Problem("No organization");
        }
        var result = await _bidconCredentialsService.GetAsync(organizationId);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] BC_DatabaseCredentialsDto credentialsDto)
    {
        var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
        if (organizationId is null)
        {
            return Problem("No organization");
        }
        await _bidconCredentialsService.UpsertAsync(credentialsDto, organizationId);
        return Ok();
    }
}
