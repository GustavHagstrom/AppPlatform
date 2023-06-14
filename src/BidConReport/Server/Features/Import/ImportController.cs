using BidConReport.Server.Data;
using BidConReport.Shared;
using BidConReport.Shared.Entities;
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
    [HttpGet("GetImportSettingsForOrganization")]
    public async Task<IActionResult> GetImportSettingsForOrganization()
    {
        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null)
        {
            return Problem();
        }

        var settings = await _applicationDbContext.EstimationImportSettings
            .Where(s => s.OrganizationId == organizationIdClaim.Value)
            .ToArrayAsync();
        return Ok(settings);
    }
    [HttpGet("GetStandardImportSettings")]
    public async Task<IActionResult> GetStandardImportSettings()
    {
        var userIdClaim = ControllerHelper.GetUserIdClaim(User);
        if (userIdClaim is null)
        {
            return NotFound(new { message = "User not found." });
        }

        var user = await _applicationDbContext.Users
            .Include(u => u.StandardEstimationSettings)
            .FirstOrDefaultAsync(u => u.Id == userIdClaim.Value);
        if (user is null || user.StandardEstimationSettings is null)
        {
            return NotFound(new { message = "Standard import settings not found for this user." });
        }
        return Ok(user.StandardEstimationSettings);
    }
    [HttpPost("UpdateOrCreateImportSettings")]
    public async Task<IActionResult> UpdateOrCreateImportSettings(EstimationImportSettings settings)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null)
        {
            return Problem();
        }

        settings.OrganizationId = organizationIdClaim.Value;

        var existingSettings = await _applicationDbContext.EstimationImportSettings
            .FirstOrDefaultAsync(s => s.OrganizationId == settings.OrganizationId && s.Id == settings.Id);

        if (existingSettings is null)
        {
            await _applicationDbContext.EstimationImportSettings.AddAsync(settings);
        }
        else
        {
            _applicationDbContext.EstimationImportSettings.Attach(existingSettings);
            _applicationDbContext.Entry(existingSettings).CurrentValues.SetValues(settings);
        }

        try
        {
            await _applicationDbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            // Log the exception or handle it appropriately.
            return Problem(detail: "An error occurred while saving the data.");
        }

        return Ok(settings);
    }
    [HttpDelete("DeleteImportSetting/{id}")]
    public async Task<IActionResult> DeleteImportSetting(int id)
    {
        var organizationIdClaim = ControllerHelper.GetOrganizationClaim(User);
        if (organizationIdClaim is null)
        {
            return Problem(detail: "Unable to determine the organization for the user.");
        }

        var importSetting = await _applicationDbContext.EstimationImportSettings
            .Where(x => x.Id == id && x.OrganizationId == organizationIdClaim.Value)
            .FirstOrDefaultAsync();

        if (importSetting is null)
        {
            return NotFound(new { message = "Import setting not found." });
        }

        try
        {
            _applicationDbContext.EstimationImportSettings.Remove(importSetting);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(new { message = "Import setting deleted successfully." });
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately.
            return Problem(detail: "An error occurred while deleting the import setting.");
        }
    }
    [HttpPost("SetAsStandard")]
    public async Task<IActionResult> SetAsStandard(EstimationImportSettings? importSetting)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var userIdClaim = ControllerHelper.GetUserIdClaim(User);
        if (userIdClaim is null)
        {
            return NotFound(new { message = "User not found." });
        }

        var currentUser = await _applicationDbContext.Users
            .Include(u => u.StandardEstimationSettings)
            .FirstOrDefaultAsync(u => u.Id == userIdClaim.Value);

        if (currentUser is null)
        {
            return NotFound(new { message = "User not found." });
        }

        if (importSetting is not null)
        {
            importSetting = await _applicationDbContext.EstimationImportSettings
            .FirstOrDefaultAsync(s => s.Id == importSetting.Id);
        }

        currentUser.StandardEstimationSettings = importSetting;

        try
        {
            await _applicationDbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately.
            return Problem(detail: "An error occurred while setting the standard import setting.");
        }
    }
}
