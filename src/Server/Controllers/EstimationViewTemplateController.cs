//using AppPlatform.Server.Services.EstimationView;
//using SharedLibrary.DTOs.EstimationView;
//using Microsoft.AspNetCore.Mvc;

//namespace AppPlatform.Server.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class EstimationViewTemplateController : ControllerBase
//{
//    private readonly IEstimationViewTemplateService _estimationViewTemplateService;
//    private readonly ILogger<EstimationViewTemplateController> _logger;

//    public EstimationViewTemplateController(IEstimationViewTemplateService estimationViewTemplateService, ILogger<EstimationViewTemplateController> logger)
//    {
//        _estimationViewTemplateService = estimationViewTemplateService;
//        _logger = logger;
//    }
//    [HttpGet("Shallow")]
//    public async Task<IActionResult> GetAllAsShallowList()
//    {
//        try
//        {
//            var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
//            ArgumentException.ThrowIfNullOrEmpty(organizationId);

//            var dto = await _estimationViewTemplateService.GetAllAsShallowListAsync(organizationId);
//            if (dto is null)
//            {
//                _logger.LogInformation("No EstimationViewTemplates found, returning NoContent");
//                return NoContent();
//            }
//            return Ok(dto);
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, "Failed to GetAllAsShallowList");
//            return Problem();
//        }
//    }
//    [HttpGet("Deep")]
//    public async Task<IActionResult> GetAllAsDeepList()
//    {
//        try
//        {
//            var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
//            ArgumentException.ThrowIfNullOrEmpty(organizationId);

//            var dto = await _estimationViewTemplateService.GetAllAsDeepListAsync(organizationId);
//            if (dto is null)
//            {
//                _logger.LogInformation("No EstimationViewTemplates found, returning NoContent");
//                return NoContent();
//            }
//            return Ok(dto);
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, "Failed to GetAllAsDeepList");
//            return Problem();
//        }
        
//    }
//    [HttpGet]
//    public async Task<IActionResult> Get([FromQuery] Guid id)
//    {
//        try
//        {
//            var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
//            ArgumentException.ThrowIfNullOrEmpty(organizationId);

//            var dto = await _estimationViewTemplateService.GetSingleDeepAsync(id, organizationId);
//            if (dto is null)
//            {
//                _logger.LogInformation("No EstimationViewTemplate found, returning NoContent");
//                return NoContent();
//            }
//            return Ok(dto);
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, "Failed to get");
//            return Problem();
//        }
        
//    }
//    [HttpPost]
//    public async Task<IActionResult> Upsert([FromBody] EstimationViewTemplateDto dto)
//    {
//        try
//        {
//            var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
//            ArgumentException.ThrowIfNullOrEmpty(organizationId);

//            await _estimationViewTemplateService.UpsertAsync(dto, organizationId);
//            return Ok();
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, "Failed to upsert");
//            return Problem();
//        }
//    }
//    [HttpDelete]
//    public async Task<IActionResult> Delete([FromQuery] Guid id)
//    {
//        try
//        {
//            var organizationId = User.FindFirst(ClaimConstants.TenantId)?.Value;
//            ArgumentException.ThrowIfNullOrEmpty(organizationId);

//            await _estimationViewTemplateService.DeleteAsync(id, organizationId);
//            return Ok();
//        }
//        catch (Exception e)
//        {
//            _logger.LogError(e, "Failed to delete");
//            throw;
//        }
//    }
//}
