using LicenseServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedBackendLibrary.Models;

namespace LicenseServer.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class LicenseController : ControllerBase
{
    [HttpGet("license")]
    public async Task<IActionResult> GetLicense(Application application)
    {
        throw new NotImplementedException();
    }
    [HttpPost("license")]
    public async Task<IActionResult> CreateLicense(Licence licence)
    {
        throw new NotImplementedException();
    }
    [HttpPut("license")]
    public async Task<IActionResult> UpdateLicense(Licence licence)
    {
        throw new NotImplementedException();
    }
}
