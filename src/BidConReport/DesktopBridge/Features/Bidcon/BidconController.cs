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
        var result = new BidConImportResult<DbFolder>(); 
        try
        {
            result.Result = _bidConImporter.GetFolderStructure();
        }
        catch (Exception e)
        {
            result.ErrorMessage = e.Message;
        }
        return await Task.FromResult(Ok(result));
    }
    [HttpGet("GetEstimations")]
    public async Task<IActionResult> GetEstimations(CancellationToken cancellationToken)
    {
        //TODO implement error message for each failed importation
        var result = new BidConImportResult<IEnumerable<DbEstimation>>();
        try
        {
            result.Result = _bidConImporter.GetAllEstimations();
        }
        catch (Exception e)
        {
            result.ErrorMessage = e.Message;
        }
        return await Task.FromResult(Ok(result));
    }
    [HttpPost("GetEstimation/{id}")]
    public async Task<IActionResult> GetEstimation(string id, [FromBody] EstimationImportSettings settings, CancellationToken cancellationToken)
    {
        //TODO implement error message 
        var result = new BidConImportResult<SimpleEstimation>();
        try
        {
            result.Result = _bidConImporter.GetEstimation(id, settings);
        }
        catch (Exception e)
        {
            result.ErrorMessage = e.Message;
            throw;
        }
        return await Task.FromResult(Ok(_bidConImporter.GetEstimation(id, settings)));
    }
}
