using BidConReport.Server.Enteties.ReportTemplate;
using BidConReport.Shared.DTOs.ReportTemplate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;

namespace BidConReport.Server.Features.Report;
[Route("api/[controller]")]
[ApiController]
public class ReportTemplatesController : ControllerBase
{
    private readonly IReportTemplatesCrudService _reportTemplatesCrudService;

    public ReportTemplatesController(IReportTemplatesCrudService reportTemplatesCrudService)
    {
        _reportTemplatesCrudService = reportTemplatesCrudService;
    }
    [HttpPost("Upsert")]
    public async Task<IActionResult> Upsert(ReportTemplate reportTemplate)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizationId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        reportTemplate.OrganizationId = currentOrgId;
        await _reportTemplatesCrudService.UpsertAsync(userId, currentOrgId, reportTemplate);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizationId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        var result = await _reportTemplatesCrudService.GetAllOrganizationTemplatesAsync(currentOrgId);
        return Ok(result);
    }
    [HttpGet("Default")]
    public async Task<IActionResult> GetDefault()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizationId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        var result = await _reportTemplatesCrudService.GetDefaultAsync(userId, currentOrgId);
        return Ok(result);
    }
    [HttpPost("SetAsDefault")]
    public async Task<IActionResult> SetAsDefault(ReportTemplate reportTemplate)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizationId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.SetAsDefaultAsync(userId, currentOrgId, reportTemplate.Id);
        return Ok();
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizationId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.DeleteAsync(id, userId, currentOrgId);
        return Ok();
    }
}
