﻿using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using BidConReport.Shared.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Services.Import;

public class ImportSettingsService : IImportSettingsService
{
    private readonly ApplicationDbContext _dbContext;

    public ImportSettingsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<EstimationImportSettingsDto?> GetDefaultSettingsAsync(string userId, int organizationId)
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
            return userOrg.DefaultEstimationSettings.Adapt<EstimationImportSettingsDto>();
        }
    }
    public async Task<ICollection<EstimationImportSettingsDto>> GetOrganizationSettingsAsync(int organizationId)
    {
        var settings = await _dbContext.EstimationImportSettings
            .Where(x => x.OrganizationId == organizationId)
            .ToArrayAsync();
        return settings.Select(x => x.Adapt<EstimationImportSettingsDto>()).ToList();
    }
    public async Task UpsertImportSettingsAsync(EstimationImportSettingsDto dto)
    {
        var dbSettings = await _dbContext.EstimationImportSettings.FindAsync(dto.Id);
        if (dbSettings is null)
        {
            await _dbContext.EstimationImportSettings.AddAsync(dto.Adapt<EstimationImportSettings>());
        }
        else
        {
            dto.Adapt(dbSettings);
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
    public async Task SetAsUserDefault(string userId, int organizationId, int? settingsId)
    {
        var userOrg = await _dbContext.UserOrganizations
            .FirstOrDefaultAsync(x => x.UserId == userId && x.OrganizationId == organizationId);
        ArgumentNullException.ThrowIfNull(userOrg);

        userOrg.DefaultEstimationSettingsId = settingsId;
        await _dbContext.SaveChangesAsync();
    }
}