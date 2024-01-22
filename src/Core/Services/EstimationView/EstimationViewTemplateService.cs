﻿using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Core.DTOs.EstimationView;
using Microsoft.Extensions.Logging;

namespace AppPlatform.Core.Services.EstimationView;

public class EstimationViewTemplateService : IEstimationViewTemplateService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEstimationViewTemplateUpdater _estimationViewTemplateUpdater;
    private readonly ILogger<IEstimationViewTemplateService> _logger;

    public delegate void UpdateAction<T>(T entityToUpdate, T updateSrcEntity) where T : IEstimationViewEntity;

    public EstimationViewTemplateService(ApplicationDbContext dbContext, IEstimationViewTemplateUpdater estimationViewTemplateUpdater, ILogger<IEstimationViewTemplateService> logger)
    {
        _dbContext = dbContext;
        _estimationViewTemplateUpdater = estimationViewTemplateUpdater;
        _logger = logger;
    }
    public async Task UpsertAsync(EstimationViewTemplateDto dto, string organizationId)
    {
        throw new NotImplementedException();
        //var existing = await _dbContext.EstimationViewTemplates
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
        //    .Include(x => x.HeaderOrFooters)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
        //    .FirstOrDefaultAsync(x => x.Id == dto.Id && x.OrganizationId == Guid.Parse(organizationId));

        //if (existing is null)
        //{
        //    _logger.LogInformation("No existing entity found. Inserting a new");
        //    var entity = dto.Adapt<EstimationViewTemplate>();
        //    entity.OrganizationId = Guid.Parse(organizationId);
        //    await _dbContext.EstimationViewTemplates.AddAsync(entity);
        //}
        //else
        //{
        //    _logger.LogInformation("Existing entity found. Updating existing");
        //    var updateSrc = dto.Adapt<EstimationViewTemplate>();
        //    updateSrc.OrganizationId = Guid.Parse(organizationId);
        //    _estimationViewTemplateUpdater.Update(existing, updateSrc);
        //    _dbContext.Update(existing);
        //}

        //await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsShallowListAsync(string organizationId)
    {
        throw new NotImplementedException();
        //var entities = await _dbContext.EstimationViewTemplates
        //    .Where(x => x.OrganizationId == Guid.Parse(organizationId))
        //    .ToListAsync();
        //var dtos = entities.Adapt<List<EstimationViewTemplateDto>>();
        //return dtos;
    }
    public async Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsDeepListAsync(string organizationId)
    {
        throw new NotImplementedException();
        //var entities = await _dbContext.EstimationViewTemplates
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
        //    .Include(x => x.HeaderOrFooters)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
        //    .Where(x => x.OrganizationId == Guid.Parse(organizationId))
        //    .ToListAsync();
        //var dtos = entities.Adapt<List<EstimationViewTemplateDto>>();
        //return dtos;
    }
    public async Task<EstimationViewTemplateDto?> GetSingleDeepAsync(Guid id, string organizationId)
    {
        throw new NotImplementedException();
        //var entity = await _dbContext.EstimationViewTemplates
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.SheetSections).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
        //    .Include(x => x.HeaderOrFooters)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Columns)
        //    .Include(x => x.DataSections).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
        //    .FirstOrDefaultAsync(x => x.Id == id && x.OrganizationId == Guid.Parse(organizationId));

        //var dto = entity?.Adapt<EstimationViewTemplateDto>();
        //return dto;
    }
    public async Task DeleteAsync(Guid id, string organizationId)
    {
        throw new NotImplementedException();
        //var entity = await _dbContext.EstimationViewTemplates.FirstOrDefaultAsync(x => x.Id == id && x.OrganizationId == Guid.Parse(organizationId));
        //if (entity is not null)
        //{
        //    _dbContext.EstimationViewTemplates.Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //}
        //else
        //{
        //    _logger.LogInformation("No entity found for the given id to delete");
        //}
    }
}