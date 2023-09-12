using BidConReport.Server.Data;
using BidConReport.Server.Enteties.EstimationView;
using BidConReport.Shared.DTOs.EstimationView;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Services;

public class EstimationViewTemplateService
{
    private readonly ApplicationDbContext _dbContext;

    public EstimationViewTemplateService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task UpsertAsync(EstimationViewTemplateDto dto)
    {
        var existing = await _dbContext.EstimationViewTemplates
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);
        if (existing is null)
        {
            var entety = dto.Adapt<EstimationViewTemplate>();
            await _dbContext.EstimationViewTemplates.AddAsync(entety);
        }
        else
        {
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            var config = new TypeAdapterConfig();
            config.Default.PreserveReference(true);
            dto.Adapt(existing, config);

            //dto.Adapt(existing);
            var state = _dbContext.Entry(existing.NetSheetSectionTemplate!.Columns.First().CellFormat).State;
            _dbContext.Update(existing);
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<EstimationViewTemplateDto>> GetAllAsShallowListAsync(string organizationId)
    {
        throw new NotImplementedException();
    }
}
