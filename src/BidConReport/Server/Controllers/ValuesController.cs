﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BidConReport.Server.Controllers;
[Route("[controller]")]
[ApiController]
[Authorize]
public class ValuesController : ControllerBase
{
    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        return await Task.FromResult(Ok($"Time: {DateTime.Now}"));
    }
}