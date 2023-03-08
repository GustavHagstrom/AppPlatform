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
        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null) return Problem();

        var settings = await _applicationDbContext.EstimationImportSettings.Where(s => s.OrganizationId == organizationIdClaim.Value).ToArrayAsync();
        return Ok(settings);
    }
    [HttpGet("GetStandardImportSettings")]
    public async Task<IActionResult> GetStandardImportSettings()
    {
        var userIdClaim = ControllerHelper.GetUserIdClaim(User);
        if (userIdClaim is null) return NotFound();

        var user = await _applicationDbContext.Users.Include(u => u.StandardSettings).Where(u => u.Id == userIdClaim.Value).FirstOrDefaultAsync();
        if (user is null || user.StandardSettings is null) return NotFound();
        return Ok(user.StandardSettings);
    }
    [HttpPost("UpsertImportSettings")]
    public async Task<IActionResult> UpsertImportSettings(EstimationImportSettings settings)
    {
        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null) return Problem();

        settings.OrganizationId = organizationIdClaim.Value;
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
    [HttpDelete("DeleteImportSetting/{id}")]
    public async Task<IActionResult> DeleteImportSetting(int id)
    {
        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null) return Problem();

        var settingToDelete = await _applicationDbContext.EstimationImportSettings.
            Where(x => x.Id == id && x.OrganizationId == organizationIdClaim.Value)
            .FirstOrDefaultAsync();

        if(settingToDelete is null) return Problem();

        _applicationDbContext.EstimationImportSettings.Remove(settingToDelete);
        await _applicationDbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("SetAsStandard")]
    public async Task<IActionResult> SetAsStandard(EstimationImportSettings? postedSetting)
    {
        var userIdClaim = ControllerHelper.GetUserIdClaim(User);
        if (userIdClaim is null) return Problem("userIdClaim is null");

        var user = await _applicationDbContext.Users.Include(u => u.StandardSettings).Where(u => u.Id == userIdClaim.Value).FirstOrDefaultAsync();
        if(user is null) return Problem("user is null");

        if (postedSetting is null)
        {
            user.StandardSettings = null;
        }
        else
        {
            var setting = await _applicationDbContext.EstimationImportSettings.Where(s => s.Id == postedSetting.Id).FirstOrDefaultAsync();
            if (setting is null) return Problem("setting is null");
            user.StandardSettings = setting;
        }
        
        await _applicationDbContext.SaveChangesAsync();
        return Ok();
    }
}
