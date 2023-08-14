using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Services.Import;

public class ImportSettingsService : IImportSettingsService
{
    private readonly ApplicationDbContext _dbContext;

    public ImportSettingsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<EstimationImportSettings?> GetDefaultSettingsAsync(string userId, string organizationId)
    {
        var userOrg = await _dbContext.UserOrganizations
            .Where(x => x.UserId == userId && x.OrganizationId == organizationId)
            .Include(x => x.DefaultEstimationSettings)
            .FirstOrDefaultAsync();

        return userOrg?.DefaultEstimationSettings;
    }
    public async Task<ICollection<EstimationImportSettings>> GetOrganizationSettingsAsync(string organizationId)
    {
        var settings = await _dbContext.EstimationImportSettings
            .Where(x => x.OrganizationId == organizationId)
            .ToArrayAsync();

        return settings;
    }
    public async Task UpsertImportSettingsAsync(EstimationImportSettings settings)
    {
        var dbSettings = await _dbContext.EstimationImportSettings.FindAsync(settings.Id);
        if (dbSettings is null)
        {
            await _dbContext.EstimationImportSettings.AddAsync(settings);
        }
        else
        {
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
    public async Task SetAsUserDefault(string userId, string organizationId, int? settingsId)
    {
        var userOrg = await _dbContext.UserOrganizations
            .FirstOrDefaultAsync(x => x.UserId == userId && x.OrganizationId == organizationId);
        ArgumentNullException.ThrowIfNull(userOrg);

        userOrg.DefaultEstimationSettingsId = settingsId;
        await _dbContext.SaveChangesAsync();
    }
}
