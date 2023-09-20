using Server.Data;
using Server.Enteties;
using SharedLibrary.DTOs.BidconAccess;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Server.Services.Settings;

public class BidconCredentialsService : IBidconCredentialsService
{
    private readonly ApplicationDbContext _context;

    public BidconCredentialsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<BC_DatabaseCredentialsDto?> GetAsync(string organizationId)
    {
        var result = await _context.BidconAccessCredentials.FirstOrDefaultAsync(x => x.OrganizationId == organizationId);
        return result?.Adapt<BC_DatabaseCredentialsDto>();
    }

    public async Task UpsertAsync(BC_DatabaseCredentialsDto credentialsDto, string organizationId)
    {
        var credentials = credentialsDto.Adapt<BidconAccessCredentials>();
        credentials.OrganizationId = organizationId;
        var existingCredentials = await _context.BidconAccessCredentials.FindAsync(organizationId);

        if (existingCredentials is null)
        {
            // Insert a new record if it doesn't exist

            credentials.LastUpdated = DateTime.UtcNow;
            _context.BidconAccessCredentials.Add(credentials);
        }
        else
        {
            // Update the existing record if it exists
            existingCredentials.Server = credentials.Server;
            existingCredentials.Database = credentials.Database;
            existingCredentials.User = credentials.User;
            existingCredentials.Password = credentials.Password;
            existingCredentials.ServerAuthentication = credentials.ServerAuthentication;
            existingCredentials.LastUpdated = DateTime.Now;
        }

        await _context.SaveChangesAsync();
    }
}
