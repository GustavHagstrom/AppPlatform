using BidConReport.DesktopBridge.Features.Bidcon.Services;
using BidConReport.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.DesktopBridge.Features.Bidcon;
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
        //TODO implement error message for each failed importation
        var result = new BidConImportResult<DbFolder> { Result = _bidConImporter.GetFolderStructure() };
        return await Task.FromResult(Ok(result));
    }
    [HttpGet("GetEstimations")]
    public async Task<IActionResult> GetEstimations(CancellationToken cancellationToken)
    {
        //TODO implement error message for each failed importation
        var result = new BidConImportResult<IEnumerable<DbEstimation>> { Result = _bidConImporter.GetAllEstimations() };
        return await Task.FromResult(Ok(result));
    }
    [HttpPost("GetEstimation/{id}")]
    public async Task<IActionResult> GetEstimation(string id, [FromBody] EstimationImportSettings settings, CancellationToken cancellationToken)
    {
        //TODO implement error message 
        var result = new BidConImportResult<SimpleEstimation> { Result = _bidConImporter.GetEstimation(id, settings) };
        return await Task.FromResult(Ok(_bidConImporter.GetEstimation(id, settings)));
    }
}
