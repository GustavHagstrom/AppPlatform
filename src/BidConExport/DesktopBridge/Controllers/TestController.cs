using Microsoft.AspNetCore.Mvc;

namespace DesktopBridge.Controllers;
[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    public TestController()
    {

    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return await Task.FromResult(Ok("Hey!"));
    }
}
