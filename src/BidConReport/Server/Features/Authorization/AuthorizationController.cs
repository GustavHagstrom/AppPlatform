//using BidConReport.Server.Data;
//using BidConReport.Server.Features.Authorization.Models;
//using BidConReport.Server.Shared.Enteties;
//using BidConReport.Shared;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Web;
//using System.Security.Claims;

//namespace BidConReport.Server.Features.Authorization;
//[Route("api/[controller]")]
//[ApiController]
//public class AuthorizationController : ControllerBase
//{
//    private readonly ApplicationDbContext _applicationDbContext;

//    public AuthorizationController(ApplicationDbContext applicationDbContext)
//    {
//        _applicationDbContext = applicationDbContext;
//    }
//    [HttpGet("Roles")]
//    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
//    {
//        var userId = User.Claims.Where(x => x.Type == ClaimConstants.ObjectId).FirstOrDefault();
//        if (userId == null) 
//        { 
//            return Ok(Array.Empty<string>()); 
//        }

//        var user = await _applicationDbContext.Users
//            .Include(u => u.Roles)
//            .Where(u => u.Id == userId.Value).FirstOrDefaultAsync(cancellationToken);
//        if(user is null) 
//        {
//            //Maybe not the correct place to add UserId to the DB?
//            var r = await _applicationDbContext.Users.AddAsync(new User { Id = userId.Value, Roles = Array.Empty<Role>() });
//            await _applicationDbContext.SaveChangesAsync();
//            return Ok(Array.Empty<string>());
//        }

//        return Ok(user.Roles.Select(r => r.Name));
//    }
//    [HttpGet("Claims")]
//    public async Task<IActionResult> GetClaims(CancellationToken cancellationToken)
//    {
//        var claims = new List<KeyValuePair<string, string>>
//        {
//            new KeyValuePair<string, string>("CustomClaimType", "CustomClaimValue"),
//        };
//        foreach (var claim in User.Claims)
//        {
//            claims.Add(new KeyValuePair<string, string>(claim.Type, claim.Value));
//        }
//        return Ok(claims);
//    }
//}
