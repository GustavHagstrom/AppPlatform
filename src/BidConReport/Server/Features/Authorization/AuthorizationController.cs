using BidConReport.Server.Data;
using BidConReport.Server.Features.Authorization.Models;
using BidConReport.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Features.Authorization;
[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AuthorizationController(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    [HttpGet("Roles")]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
    {
        var userId = User.Claims.Where(x => x.Type == AppConstants.UserIdClaimKey).FirstOrDefault();
        if (userId == null) 
        { 
            return Ok(Array.Empty<string>()); 
        }

        var user = await _applicationDbContext.Users
            .Include(u => u.Roles)
            .Where(u => u.Id == userId.Value).FirstOrDefaultAsync(cancellationToken);
        if(user is null) 
        {
            //Maybe not the correct place to add UserId to the DB?
            var r = await _applicationDbContext.Users.AddAsync(new User { Id = userId.Value, Roles = Array.Empty<Role>() });
            await _applicationDbContext.SaveChangesAsync();
            return Ok(Array.Empty<string>());
        }

        return Ok(user.Roles.Select(r => r.Name));
    }
}
