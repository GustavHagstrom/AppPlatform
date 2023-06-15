using BidConReport.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace BidConReport.Server.Features.Import;
[Route("api/[controller]")]
[ApiController]
public class ImportController : ControllerBase
{
    private readonly IImportSettingsService _importSettingsService;
    private readonly ILogger<ImportController> _logger;

    public ImportController( IImportSettingsService importSettingsService, ILogger<ImportController> logger)
    {
        _importSettingsService = importSettingsService;
        _logger = logger;
    }
    [HttpGet("GetImportSettingsForOrganization")]
    public async Task<IActionResult> GetImportSettingsForOrganization()
    {
        try
        {
            var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(userId);
            var result = await _importSettingsService.GetCurrentOrganizationSettingsAsync(userId);
            return Ok(result);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, "UserId was null");
            return Problem("UserId was null");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
    [HttpGet("GetStandardImportSettings")]
    public async Task<IActionResult> GetStandardImportSettings()
    {
        try
        {
            var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(userId);
            var settings = await _importSettingsService.GetCurrentsDefaultSettingsAsync(userId);
            ArgumentNullException.ThrowIfNull(settings);
            return Ok(settings);
        }
        catch(ArgumentNullException e)
        {
            _logger.LogError(e, "UserId or ImportSettings was null");
            return Problem("UserId or ImportSettings was null");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
    [HttpPost("UpdateOrCreateImportSettings")]
    public async Task<IActionResult> UpdateOrCreateImportSettings(EstimationImportSettings settings)
    {
        //TODO: add role constraint, maybe admin?? IF update also check for organization
        try
        {
            await _importSettingsService.UpsertImportSettingsAsync(settings);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
    [HttpDelete("DeleteImportSetting/{id}")]
    public async Task<IActionResult> DeleteImportSetting(int id)
    {
        //TODO: add role constraint and check that the user belongs to the organization the settings applies to
        try
        {
            await _importSettingsService.DeleteSettingsAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
    [HttpPost("SetAsStandard")]
    public async Task<IActionResult> SetAsStandard(int? settingsId)
    {
        //TODO: check for organization
        try
        {
            var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(userId);
            await _importSettingsService.SetAsUserDefault(userId, settingsId);
            return Ok();
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, "Required values were null");
            return Problem("Required values were null");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
}
