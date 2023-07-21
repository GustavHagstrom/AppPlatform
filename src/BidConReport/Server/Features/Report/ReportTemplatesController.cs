using BidConReport.Shared.Features.ReportTemplate;
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
        await _reportTemplatesCrudService.UpsertAsync(reportTemplate);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currentOrgId = User.Claims.Where(x => x.Type == CustomClaimTypes.CurrentOrganization).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(currentOrgId);
        var result = await _reportTemplatesCrudService.GetAllOrganizationTemplatesAsync(currentOrgId);
        return Ok(result);
    }
    [HttpGet("Default")]
    public async Task<IActionResult> GetDefault()
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        var result = await _reportTemplatesCrudService.GetDefaultAsync(userId);
        return Ok(result);
    }
    [HttpPost("SetAsDefault")]
    public async Task<IActionResult> SetAsDefault(ReportTemplate reportTemplate)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.SetAsDefaultAsync(userId, reportTemplate.Id);
        return Ok();
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(ReportTemplate reportTemplate)
    {
        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault()?.Value;
        ArgumentNullException.ThrowIfNull(userId);
        await _reportTemplatesCrudService.DeleteAsync(reportTemplate.Id, userId);
        return Ok();
    }
}
