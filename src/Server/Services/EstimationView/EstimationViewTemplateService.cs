using Server.Data;
using Server.Enteties.EstimationView;
using SharedLibrary.DTOs.EstimationView;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Server.Services.EstimationView;

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
        var existing = await _dbContext.EstimationViewTemplates
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync(x => x.Id == dto.Id && x.OrganizationId == organizationId);

        if (existing is null)
        {
            _logger.LogInformation("No existing entity found. Inserting a new");
            var entity = dto.Adapt<EstimationViewTemplate>();
            entity.OrganizationId = organizationId;
            await _dbContext.EstimationViewTemplates.AddAsync(entity);
        }
        else
        {
            _logger.LogInformation("Existing entity found. Updating existing");
            var updateSrc = dto.Adapt<EstimationViewTemplate>();
            updateSrc.OrganizationId = organizationId;
            _estimationViewTemplateUpdater.Update(existing, updateSrc);
            _dbContext.Update(existing);
        }

        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsShallowListAsync(string organizationId)
    {
        var entities = await _dbContext.EstimationViewTemplates
            .Where(x => x.OrganizationId == organizationId)
            .ToListAsync();
        var dtos = entities.Adapt<List<EstimationViewTemplateDto>>();
        return dtos;
    }
    public async Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsDeepListAsync(string organizationId)
    {
        var entities = await _dbContext.EstimationViewTemplates
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .Where(x => x.OrganizationId == organizationId)
            .ToListAsync();
        var dtos = entities.Adapt<List<EstimationViewTemplateDto>>();
        return dtos;
    }
    public async Task<EstimationViewTemplateDto?> GetSingleDeepAsync(Guid id, string organizationId)
    {
        var entity = await _dbContext.EstimationViewTemplates
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.SheetSectionTemplates).ThenInclude(x => x.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync(x => x.Id == id && x.OrganizationId == organizationId);

        var dto = entity?.Adapt<EstimationViewTemplateDto>();
        return dto;
    }
    public async Task DeleteAsync(Guid id, string organizationId)
    {
        var entity = await _dbContext.EstimationViewTemplates.FirstOrDefaultAsync(x => x.Id == id && x.OrganizationId == organizationId);
        if (entity is not null)
        {
            _dbContext.EstimationViewTemplates.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogInformation("No entity found for the given id to delete");
        }
    }
}
