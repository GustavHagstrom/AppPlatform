using BidConReport.Server.Data;
using BidConReport.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;

namespace BidConReport.Server.Features.Import;
[Route("api/[controller]")]
[ApiController]
public class ImportSettingsController : ControllerBase
{
    private readonly IImportSettingsService _importSettingsService;
    private readonly ILogger<ImportSettingsController> _logger;

    public ImportSettingsController(IImportSettingsService importSettingsService, ILogger<ImportSettingsController> logger)
    //public ImportController(ApplicationDbContext dbContext, ILogger<ImportController> logger)
    {
        _importSettingsService = importSettingsService;
        //_importSettingsService = new ImportSettingsService(dbContext);
        _logger = logger;
    }
    [HttpGet("All")]
    public async Task<IActionResult> All()
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
    [HttpGet("Default")]
    public async Task<IActionResult> Default()
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
    [HttpPost("upsert")]
    public async Task<IActionResult> Upsert([FromBody] EstimationImportSettings settings)
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
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
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
    [HttpPost("SetDefault")]
    public async Task<IActionResult> SetDefault([FromBody] int? settingsId)
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
