using BidConReport.Server.Data;
using BidConReport.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Features.Import;

public class ImportSettingsService : IImportSettingsService
{
    private readonly ApplicationDbContext _dbContext;

    public ImportSettingsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<EstimationImportSettings?> GetCurrentsDefaultSettingsAsync(string userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user is null || user.CurrentUserOrganizationId is null)
        {
            return null;
        }
        var currentUserOrg = await _dbContext.UserOrganizations
            .Include(x => x.StandardEstimationSettings)
            .FirstOrDefaultAsync(x => x.Id == user.CurrentUserOrganizationId);

        return currentUserOrg?.StandardEstimationSettings;
    }
    public async Task<ICollection<EstimationImportSettings>> GetCurrentOrganizationSettingsAsync(string userId)
    {
        var settings = new List<EstimationImportSettings>();
        var user = await _dbContext.Users
            .Include(x => x.CurrentUserOrganization)
            .Where(x => x.Id == userId)
            .FirstOrDefaultAsync();
        if (user is null || user.CurrentUserOrganization is null)
        {
            return settings;
        }
        var result = await _dbContext.EstimationImportSettings
            .Where(x => x.OrganizationId == user.CurrentUserOrganization.OrganizationId)
            .ToArrayAsync();
        settings.AddRange(result);

        return settings;
    }
    public async Task UpsertImportSettingsAsync(EstimationImportSettings settings)
    {
        var dbSettings = await _dbContext.EstimationImportSettings.FindAsync(settings.Id);
        if(dbSettings is null) 
        {
            await _dbContext.EstimationImportSettings.AddAsync(settings);
        }
        else
        {
            _dbContext.EstimationImportSettings.Attach(settings);
            _dbContext.Entry(dbSettings).CurrentValues.SetValues(settings);
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteSettingsAsync(int settingsId)
    {
        var dbSettings = await _dbContext.EstimationImportSettings.FindAsync(settingsId);
        if (dbSettings is not null)
        {
            _dbContext.EstimationImportSettings.Remove(dbSettings);
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task SetAsUserDefault(string userId, int? settingsId)
    {
        var user = await _dbContext.Users
            .Include(x => x.CurrentUserOrganization)
            .FirstOrDefaultAsync(x => x.Id == userId);
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(user.CurrentUserOrganization);

        user.CurrentUserOrganization.StandardEstimationSettingsId = settingsId;
        await _dbContext.SaveChangesAsync();
    }
}
