using Microsoft.AspNetCore.Mvc;

namespace BidconLink.Controllers;

[Route("api/[controller]")]
[ApiController]
public class testController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Task.FromResult(Ok("Hello world!"));
    }
}
