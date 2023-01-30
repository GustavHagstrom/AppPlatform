using ApiClient.Bidcon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace ApiClient.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize(Roles = "admin,kalkyl")]
public class BidconController : ControllerBase
{
    private readonly IBidConImporter _bidConImporter;

    public BidconController(IBidConImporter bidConImporter)
    {
        _bidConImporter = bidConImporter;
    }
    [HttpGet("GetFolders")]
    public async Task<IActionResult> GetFolders()
    {
        try
        {
            return await Task.FromResult(Ok(_bidConImporter.GetFolderStructure()));
        }
        catch (Exception e)
        {
            throw;
            return await Task.FromResult(Problem(e.Message));
        }
    }
    [HttpGet("GetEstimations")]
    public async Task<IActionResult> GetEstimations()
    {
        try
        {
            return await Task.FromResult(Ok(_bidConImporter.GetAllEstimations()));
        }
        catch (Exception e)
        {
            throw;
            return await Task.FromResult(Problem(e.Message));
        }
    }
    [HttpPost("GetEstimation/{id}")]
    //[ActionName("GetEstimation")]
    public async Task<IActionResult> GetEstimation(string id, [FromBody] EstimationImportSettings settings)
    {
        try
        {
            var result = await Task.FromResult(Ok(_bidConImporter.GetEstimation(id, settings)));
            return result;
        }
        catch (Exception e)
        {
            throw;
            return await Task.FromResult(Problem(e.Message));
        }
    }
}
