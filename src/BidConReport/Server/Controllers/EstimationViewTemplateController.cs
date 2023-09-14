using BidConReport.Server.Services.EstimationView;
using BidConReport.Shared.DTOs.EstimationView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace BidConReport.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstimationViewTemplateController : ControllerBase
{
    private readonly IEstimationViewTemplateService _estimationViewTemplateService;
    private readonly ILogger<EstimationViewTemplateController> _logger;

    public EstimationViewTemplateController(IEstimationViewTemplateService estimationViewTemplateService, ILogger<EstimationViewTemplateController> logger)
    {
        _estimationViewTemplateService = estimationViewTemplateService;
        _logger = logger;
    }
    [HttpGet("Shallow")]
    public async Task<IActionResult> GetAllAsShallowList()
    {
        var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
        ArgumentException.ThrowIfNullOrEmpty(organizationId);

        var dto = await _estimationViewTemplateService.GetAllAsShallowListAsync(organizationId);
        if (dto is null)
        {
            _logger.LogInformation("No EstimationViewTemplates found, returning NoContent");
            return NoContent();
        }
        return Ok(dto);
    }
    [HttpGet("Deep")]
    public async Task<IActionResult> GetAllAsDeepList()
    {
        var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
        ArgumentException.ThrowIfNullOrEmpty(organizationId);

        var dto = await _estimationViewTemplateService.GetAllAsDeepListAsync(organizationId);
        if (dto is null)
        {
            _logger.LogInformation("No EstimationViewTemplates found, returning NoContent");
            return NoContent();
        }
        return Ok(dto);
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Guid id)
    {
        var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
        ArgumentException.ThrowIfNullOrEmpty(organizationId);

        var dto = await _estimationViewTemplateService.GetSingleDeepAsync(id, organizationId);
        if (dto is null)
        {
            _logger.LogInformation("No EstimationViewTemplate found, returning NoContent");
            return NoContent();
        }
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> Upsert([FromBody] EstimationViewTemplateDto dto)
    {
        var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
        ArgumentException.ThrowIfNullOrEmpty(organizationId);
        try
        {
            await _estimationViewTemplateService.UpsertAsync(dto, organizationId);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to upsert");
            return Problem();
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
        ArgumentException.ThrowIfNullOrEmpty(organizationId);

        try
        {
            await _estimationViewTemplateService.DeleteAsync(id, organizationId);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to delete");
            throw;
        }
    }
}
