using BidConReport.Server.Enteties.Report;
using BidConReport.Server.Services.Report;
using BidConReport.Shared.DTOs.ReportTemplate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;

namespace BidConReport.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportTemplatesController : ControllerBase
{
    private readonly IReportTemplatesService _reportTemplatesCrudService;

    public ReportTemplatesController(IReportTemplatesService reportTemplatesCrudService)
    {
        _reportTemplatesCrudService = reportTemplatesCrudService;
    }
    [HttpPost("Upsert")]
    public async Task<IActionResult> Upsert(ReportTemplateDto dto)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizatio).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        dto.OrganizationId = currentOrgId;
        await _reportTemplatesCrudService.UpsertAsync(userId, currentOrgId, dto);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizatio).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        var result = await _reportTemplatesCrudService.GetAllOrganizationTemplatesAsync(currentOrgId);
        return Ok(result);
    }
    [HttpGet("Default")]
    public async Task<IActionResult> GetDefault()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizatio).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        var result = await _reportTemplatesCrudService.GetDefaultAsync(userId, currentOrgId);
        return Ok(result);
    }
    [HttpPost("SetAsDefault")]
    public async Task<IActionResult> SetAsDefault(ReportTemplateDto dto)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizatio).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.SetAsDefaultAsync(userId, currentOrgId, dto.Id);
        return Ok();
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganizatio).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.DeleteAsync(id, userId, currentOrgId);
        return Ok();
    }
}
