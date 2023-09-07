using BidConReport.Server.Enteties.Report;
using BidConReport.Server.Services.Report;
using BidConReport.Shared.DTOs.ReportTemplate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using SharedPlatformLibrary.Constants;
using System.Security.Claims;

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
        var userId = User.FindFirstValue(ClaimConstants.ObjectId);
        var currentOrgId = User.FindFirstValue(ClaimConstants.TenantId);

        ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
        ArgumentException.ThrowIfNullOrEmpty(userId);
        dto.OrganizationId = int.Parse(currentOrgId);
        await _reportTemplatesCrudService.UpsertAsync(userId, int.Parse(currentOrgId), dto);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
        ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
        var result = await _reportTemplatesCrudService.GetAllOrganizationTemplatesAsync(int.Parse(currentOrgId));
        return Ok(result);
    }
    [HttpGet("Default")]
    public async Task<IActionResult> GetDefault()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
        ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
        ArgumentException.ThrowIfNullOrEmpty(userId);
        var result = await _reportTemplatesCrudService.GetDefaultAsync(userId, int.Parse(currentOrgId));
        return Ok(result);
    }
    [HttpPost("SetAsDefault")]
    public async Task<IActionResult> SetAsDefault(ReportTemplateDto dto)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
        ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
        ArgumentException.ThrowIfNullOrEmpty(userId);
        await _reportTemplatesCrudService.SetAsDefaultAsync(userId, int.Parse(currentOrgId), dto.Id);
        return Ok();
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
        ArgumentException.ThrowIfNullOrEmpty(currentOrgId);
        ArgumentException.ThrowIfNullOrEmpty(userId);
        await _reportTemplatesCrudService.DeleteAsync(id, userId, int.Parse(currentOrgId));
        return Ok();
    }
}
