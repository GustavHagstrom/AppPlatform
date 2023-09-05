using Azure.Core;
using BidconLink.Services;
using BidConReport.Shared.DTOs.BidconAccess;
using Microsoft.AspNetCore.Mvc;

namespace BidconLink.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BidconAccessController : ControllerBase
{
    private readonly IEstimationQueryService _estimationQueryService;

    public BidconAccessController(IEstimationQueryService estimationQueryService)
    {
        _estimationQueryService = estimationQueryService;
    }

    [HttpPost("GetEstimationBatch")]
    public async Task<IActionResult> GetEstimationBatch([FromBody] EstimationRequestBatchModelDto request)
    {
        var result = await _estimationQueryService.GetEstimationBatchAsync(request.EstimationId, request.Credentials);
        return Ok(result);
    }

    [HttpPost("GetEstimationBatches")]
    public async Task<IActionResult> GetEstimationBatches([FromBody] EstimationRequestBatchesModelDto request)
    {
        var result = await _estimationQueryService.GetEstimationBatchesAsync(request.EstimationIds, request.Credentials);
        return Ok(result);
    }

    [HttpPost("GetEstimationList")]
    public async Task<IActionResult> GetEstimationList([FromBody] BC_DatabaseCredentialsDto credentials)
    {
        var result = await _estimationQueryService.GetEstimationListAsync(credentials);
        return Ok(result);
    }

    [HttpPost("GetFolderBatch")]
    public async Task<IActionResult> GetFolderBatch([FromBody] BC_DatabaseCredentialsDto credentials)
    {
        var result = await _estimationQueryService.GetFolderBatchAsync(credentials);
        return Ok(result);
    }
}
