using BidConReport.Server.Services.Import;
using BidConReport.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;

namespace BidConReport.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImportSettingsController : ControllerBase
{
    private readonly IImportSettingsService _importSettingsService;
    private readonly ILogger<ImportSettingsController> _logger;

    public ImportSettingsController(IImportSettingsService importSettingsService, ILogger<ImportSettingsController> logger)
    {
        _importSettingsService = importSettingsService;
        _logger = logger;
    }
    [HttpGet("All")]
    public async Task<IActionResult> All()
    {
        try
        {
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
            var result = await _importSettingsService.GetOrganizationSettingsAsync(int.Parse(currentOrgId));
            return Ok(result);
        }
        catch (ArgumentException e)
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
            ArgumentException.ThrowIfNullOrEmpty(userId);
            ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
            var settingsDto = await _importSettingsService.GetDefaultSettingsAsync(userId, int.Parse(currentOrgId));
            return Ok(settingsDto);
        }
        catch (ArgumentException e)
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
    public async Task<IActionResult> Upsert([FromBody] EstimationImportSettingsDto dto)
    {
        //TODO: add role constraint, maybe admin?? IF update also check for organization
        try
        {
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
            dto.OrganizationId = int.Parse(currentOrgId);
            await _importSettingsService.UpsertImportSettingsAsync(dto);
            return Ok();
        }
        catch (ArgumentException e)
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
    public async Task<IActionResult> SetDefault([FromBody] EstimationImportSettingsDto? settings)
    {
        //TODO: check for organization
        try
        {
            var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
            var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
            ArgumentException.ThrowIfNullOrEmpty(userId);
            ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
            await _importSettingsService.SetAsUserDefault(userId, int.Parse(currentOrgId), settings?.Id);
            return Ok();
        }
        catch (ArgumentException e)
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
