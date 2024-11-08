using Microsoft.AspNetCore.Mvc;

namespace AppPlatform.BidconLink.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BidconAccessController : ControllerBase
{
    //private readonly IEstimationQueryService _estimationQueryService;
    //private readonly ILogger<BidconAccessController> _logger;
    //public BidconAccessController(IEstimationQueryService estimationQueryService, ILogger<BidconAccessController> logger)
    //{
    //    _estimationQueryService = estimationQueryService;
    //    _logger = logger;
    //}

    //[HttpPost("GetEstimationBatch")]
    //public async Task<IActionResult> GetEstimationBatch([FromBody] D_EstimationRequestBatchModel request)
    //{
    //    var result = await _estimationQueryService.GetEstimationBatchAsync(request.EstimationId, HttpContext.User);
    //    return Ok(result);
    //}

    //[HttpPost("GetEstimationBatches")]
    //public async Task<IActionResult> GetEstimationBatches([FromBody] D_EstimationRequestBatchesModel request)
    //{
    //    var result = await _estimationQueryService.GetEstimationBatchesAsync(request.EstimationIds, HttpContext.User);
    //    return Ok(result);
    //}

    //[HttpGet("GetEstimationList")]
    //public async Task<IActionResult> GetEstimationList(CancellationToken cancellationToken = default)
    //{
    //    var result = await _estimationQueryService.GetEstimationListAsync(HttpContext.User);
    //    return Ok(result);
    //}

    //[HttpGet("GetFolderBatch")]
    //public async Task<IActionResult> GetFolderBatch(CancellationToken cancellationToken = default)
    //{
    //    var result = await _estimationQueryService.GetFolderBatchAsync(HttpContext.User);
    //    return Ok(result);
    //}
}
