using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using BidConReport.Server.Mappers;
using BidConReport.Shared.DTOs;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Services.Import;

public class ImportSettingsService : IImportSettingsService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ImportSettingsMapper _mapper;

    public ImportSettingsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _mapper = new ImportSettingsMapper();
    }
    public async Task<EstimationImportSettingsDto?> GetDefaultSettingsAsync(string userId, string organizationId)
    {
        var userOrg = await _dbContext.UserOrganizations
            .Where(x => x.UserId == userId && x.OrganizationId == organizationId)
            .Include(x => x.DefaultEstimationSettings)
            .FirstOrDefaultAsync();

        if (userOrg?.DefaultEstimationSettings is null)
        {
            return null;
        }
        else
        {
            var dto = _mapper.ToDto(userOrg?.DefaultEstimationSettings!);
            return dto;
        }
    }
    public async Task<ICollection<EstimationImportSettingsDto>> GetOrganizationSettingsAsync(string organizationId)
    {
        var settings = await _dbContext.EstimationImportSettings
            .Where(x => x.OrganizationId == organizationId)
            .ToArrayAsync();
        return settings.Select(x => _mapper.ToDto(x)).ToList();
    }
    public async Task UpsertImportSettingsAsync(EstimationImportSettingsDto dto)
    {
        var dbSettings = await _dbContext.EstimationImportSettings.FindAsync(dto.Id);
        if (dbSettings is null)
        {
            await _dbContext.EstimationImportSettings.AddAsync(_mapper.FromDto(dto));
        }
        else
        {
            dbSettings = _mapper.FromDto(dto);
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
