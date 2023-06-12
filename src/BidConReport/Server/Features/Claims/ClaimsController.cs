using BidConReport.Server.Data;
using BidConReport.Server.Features.Authorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

namespace BidConReport.Server.Features.Claims;
[Route("api/[controller]")]
[ApiController]
public class ClaimsController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ClaimsController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetClaims(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}