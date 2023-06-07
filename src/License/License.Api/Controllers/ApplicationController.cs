using Microsoft.AspNetCore.Mvc;
using License.Api.Entities;
using LicenseLibrary;
using Microsoft.EntityFrameworkCore;
using SharedPlatformLibrary.Enteties;

namespace License.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly LicenseDbContext _dbContext;
    private readonly ILogger<ApplicationController> _logger;

    public ApplicationController(LicenseDbContext dbContext, ILogger<ApplicationController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    [HttpPost("Seed")]
    public async Task<IActionResult> Seed([FromBody]AppSeedModel dataSeedModel)
    {
        try
        {
            await _dbContext.Database.EnsureCreatedAsync();
            await _dbContext.Database.MigrateAsync();
            var application = await _dbContext.Applications.Where(x => x.Name == dataSeedModel.ApplicationName).FirstOrDefaultAsync();
            bool changesMade = false;
            if (application is null)
            {
                await _dbContext.Applications.AddAsync(new Application { Name = dataSeedModel.ApplicationName });
                changesMade = true;
            }
            List<Role> roles = new List<Role>();
            if (application is not null)
            {
                roles = await _dbContext.Roles.Where(x => x.ApplicationId == application.Id).ToListAsync();
            }
            var roleNames = roles.Select(x => x.Name).ToArray();
            foreach (var roleName in dataSeedModel.Roles)
            {
                if (!roleNames.Contains(roleName))
                {
                    await _dbContext.Roles.AddAsync(new Role { ApplicationId = application.Id, Name = roleName });
                    changesMade = true;
                }
            }
            if (changesMade)
            {
                await _dbContext.SaveChangesAsync();
            }
            return Ok();
        }
        catch (Exception e)
        {
            string message = $"Exception during database seed from application: {dataSeedModel.ApplicationName}";
            _logger.LogCritical(e, message);
            return Problem(message);
        }
    }
}
