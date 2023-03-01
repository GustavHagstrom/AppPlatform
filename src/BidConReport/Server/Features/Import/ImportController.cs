using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.Server.Features.Import;
[Route("api/[controller]")]
[ApiController]
public class ImportController : ControllerBase
{
    [HttpGet("GetAllImportSettings")]
    public async Task<IActionResult> GetAllImportSettings()
    {
        return await Task.FromResult(Ok("Success"));
    }
    [HttpGet("GetStandardImportSettings")]
    public Task<IActionResult> GetStandardImportSettings()
    {
        throw new NotImplementedException();
    }
}
