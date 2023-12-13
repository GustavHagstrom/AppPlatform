//using SharedLibrary.DTOs.BidconAccess;
//using Microsoft.AspNetCore.Mvc;
//using BidconDataAccess;
//using System.Security.Claims;

//namespace Server.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class BidconAccessController : ControllerBase
//{
//    private readonly IEstimationQueryService _estimationQueryService;
//    private readonly ILogger<BidconAccessController> _logger;
//    public BidconAccessController(IEstimationQueryService estimationQueryService, ILogger<BidconAccessController> logger)
//    {
//        _estimationQueryService = estimationQueryService;
//        _logger = logger;
//    }

//    [HttpPost("GetEstimationBatch")]
//    public async Task<IActionResult> GetEstimationBatch([FromBody] EstimationRequestBatchModelDto request)
//    {
//        try
//        {
//            var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
//            if (organizationId is null)
//            {
//                return Problem("No organization");
//            }
//            var result = await _estimationQueryService.GetEstimationBatchAsync(request.EstimationId, organizationId);
//            return Ok(result);
//        }
//        catch (ArgumentException ex)
//        {
//            _logger.LogError(ex, "Probably null or empty database credentials");
//            return BadRequest(ex.Message);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Unexpected error");
//            return Problem(ex.Message);
//        }
//    }

//    [HttpPost("GetEstimationBatches")]
//    public async Task<IActionResult> GetEstimationBatches([FromBody] EstimationRequestBatchesModelDto request)
//    {
//        try
//        {
//            var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
//            if (organizationId is null)
//            {
//                return Problem("No organization");
//            }
//            var result = await _estimationQueryService.GetEstimationBatchesAsync(request.EstimationIds, organizationId);
//            return Ok(result);
//        }
//        catch (ArgumentException ex)
//        {
//            _logger.LogError(ex, "Probably null or empty database credentials");
//            return BadRequest(ex.Message);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Unexpected error");
//            return Problem(ex.Message);
//        }
//    }

//    [HttpGet("GetEstimationList")]
//    public async Task<IActionResult> GetEstimationList(CancellationToken cancellationToken = default)
//    {
//        try
//        {
//            var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
//            if (organizationId is null)
//            {
//                return Problem("No organization");
//            }
//            var result = await _estimationQueryService.GetEstimationListAsync(organizationId);
//            return Ok(result);
//        }
//        catch (ArgumentException ex)
//        {
//            _logger.LogError(ex, "Probably null or empty database credentials");
//            return BadRequest(ex.Message);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Unexpected error");
//            return Problem(ex.Message);
//        }
//    }

//    [HttpGet("GetFolderBatch")]
//    public async Task<IActionResult> GetFolderBatch(CancellationToken cancellationToken = default)
//    {
//        try
//        {
//            var organizationId = User.FindFirstValue(ClaimConstants.TenantId);
//            if (organizationId is null)
//            {
//                return Problem("No organization");
//            }
//            var result = await _estimationQueryService.GetFolderBatchAsync(organizationId);
//            return Ok(result);
//        }
//        catch (ArgumentException ex)
//        {
//            _logger.LogError(ex, "Probably null or empty database credentials");
//            return BadRequest(ex.Message);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Unexpected error");
//            return Problem(ex.Message);
//        }
//    }
//}
