using BidConReport.DesktopBridge.Features.Bidcon.Services;
using BidConReport.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace BidConReport.DesktopBridge.Features.Bidcon;
[Route("[controller]")]
[ApiController]
public class BidconController : ControllerBase
{
    private readonly IBidConImporter _bidConImporter;
    private readonly IBidconDataConverter _bidconDataConverter;

    public BidconController(IBidConImporter bidConImporter, IBidconDataConverter bidconDataConverter)
    {
        _bidConImporter = bidConImporter;
        _bidconDataConverter = bidconDataConverter;
    }
    [HttpGet("GetFolders")]
    public async Task<IActionResult> GetFolders(CancellationToken cancellationToken)
    {
        //TODO implement error message for each failed importation
        var result = new BidConImportResult<DbFolder>();
        try
        {
            var folder = _bidConImporter.GetDatabaseFolder();
            result.Value = _bidconDataConverter.ConvertDatabaseFolder(folder);
        }
        catch (FileNotFoundException e)
        {
            result.ErrorMessage = $"""File at location: "{e.Message}" was not found""";
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
        var result = new BidConImportResult<Estimation>();
        try
        {
            var estimation = _bidConImporter.GetEstimation(id);
            result.Value = _bidconDataConverter.ConvertEstimation(estimation, settings);
        }
        catch (Exception e)
        {
            result.ErrorMessage = $"Error @{id}. Message: {e.Message}";
            //result.ErrorMessage = "server error";
        }
        return await Task.FromResult(Ok(result));
    }
}
