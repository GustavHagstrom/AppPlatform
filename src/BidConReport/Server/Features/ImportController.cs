using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.Server.Features;
[Route("[controller]")]
[ApiController]
public class ImportController : ControllerBase
{
    [HttpGet("GetAllImportSettings")]
    public async Task<IActionResult> GetAllImportSettings()
    {
        throw new NotImplementedException();
    }
    [HttpGet("GetStandardImportSettings")]
    public async Task<IActionResult> GetStandardImportSettings()
    {
        throw new NotImplementedException();
    }
}
