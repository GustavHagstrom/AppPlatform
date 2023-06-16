using BidConReport.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;

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
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(currentOrgId);
            var result = await _importSettingsService.GetOrganizationSettingsAsync(currentOrgId);
            return Ok(result);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, "CurrentOrganization claim was not found");
            return Problem("CurrentOrganization claim was not found");
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
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(currentOrgId);
            var settings = await _importSettingsService.GetDefaultSettingsAsync(userId, currentOrgId);
            return Ok(settings);
        }
        catch(ArgumentNullException e)
        {
            _logger.LogError(e, "UserId claim or CurrentOrganization claim was null");
            return Problem("UserId claim or CurrentOrganization claim was null");
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
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentNullException.ThrowIfNull(userId);
            ArgumentNullException.ThrowIfNull(currentOrgId);
            await _importSettingsService.SetAsUserDefault(userId, currentOrgId, settingsId);
            return Ok();
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError(e, "UserId claim or CurrentOrganization claim was null");
            return Problem("UserId claim or CurrentOrganization claim was null");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unexpected server error");
            return Problem("Unexpected server error");
        }
    }
}
