using BidConReport.Shared.Features.ReportTemplate;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.Server.Features.Report;
[Route("api/[controller]")]
[ApiController]
public class ReportTemplatesController : ControllerBase
{
    [HttpPost("Upsert")]
    public async Task<IActionResult> Upsert(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }
    [HttpGet]
    public async Task<IActionResult> GetDefault()
    {
        throw new NotImplementedException();
    }
    [HttpPost("SetAsDefault")]
    public async Task<IActionResult> SetAsDefault(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
}
