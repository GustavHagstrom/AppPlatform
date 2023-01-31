using DesktopBridge.Features.Bidcon.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon;
[Route("[controller]")]
[ApiController]
public class BidconController : ControllerBase
{
    private readonly IBidConImporter _bidConImporter;

    public BidconController(IBidConImporter bidConImporter)
    {
        _bidConImporter = bidConImporter;
    }
    [HttpGet("GetFolders")]
    public async Task<IActionResult> GetFolders(CancellationToken cancellationToken)
    {
        return await Task.FromResult(Ok(_bidConImporter.GetFolderStructure()));
    }
    [HttpGet("GetEstimations")]
    public async Task<IActionResult> GetEstimations(CancellationToken cancellationToken)
    {
        return await Task.FromResult(Ok(_bidConImporter.GetAllEstimations()));
    }
    [HttpPost("GetEstimation/{id}")]
    public async Task<IActionResult> GetEstimation(string id, [FromBody] EstimationImportSettings settings, CancellationToken cancellationToken)
    {
        var result = await Task.FromResult(Ok(_bidConImporter.GetEstimation(id, settings)));
        return result;  
    }
}
