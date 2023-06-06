using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace License.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    [HttpGet("Me")]
    public async Task<IActionResult> Me()
    {
        throw new NotImplementedException();
    }
}
