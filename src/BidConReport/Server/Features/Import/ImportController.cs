using BidConReport.Server.Data;
using BidConReport.Shared;
using BidConReport.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Features.Import;
[Route("api/[controller]")]
[ApiController]
public class ImportController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ImportController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    [HttpGet("GetAllImportSettings")]
    public async Task<IActionResult> GetAllImportSettings()
    {
        var organizationIdClaim = User.Claims.Where(x => x.Type == AppConstants.OrganizationIdClaimKey).FirstOrDefault();
        if (organizationIdClaim is null) return Problem();

        var settings = await _applicationDbContext.EstimationImportSettings.Where(s => s.OrganizationId == organizationIdClaim.Value).ToArrayAsync();
        return Ok(settings);
    }
    [HttpGet("GetStandardImportSettings")]
    public async Task<IActionResult> GetStandardImportSettings()
    {
        var userIdClaim = User.Claims.Where(x => x.Type == AppConstants.UserIdClaimKey).FirstOrDefault();
        if (userIdClaim is null) return NotFound();
        var user = await _applicationDbContext.Users.Include(u => u.StandardSettings).Where(u => u.Id == userIdClaim.Value).FirstOrDefaultAsync();
        if (user is null || user.StandardSettings is null) return NotFound();
        return Ok(user.StandardSettings);
    }
    [HttpPost("UpsertImportSettings")]
    public async Task<IActionResult> UpsertImportSettings(EstimationImportSettings settings)
    {
        var organizationIdClaim = User.Claims.Where(x => x.Type == AppConstants.OrganizationIdClaimKey).FirstOrDefault();
        if (organizationIdClaim is null) return Problem();

        var dbSettings = await _applicationDbContext.EstimationImportSettings
            .Where(s => s.OrganizationId == organizationIdClaim.Value && s.Id == settings.Id)
            .FirstOrDefaultAsync();
        if (dbSettings is null)
        {
            await _applicationDbContext.EstimationImportSettings.AddAsync(settings);
        }
        else
        {
            dbSettings = settings;
        }
        await _applicationDbContext.SaveChangesAsync();
        return Ok();

    }
}
