using BidConReport.Server.Data;
using BidConReport.Server.Enteties.EstimationView;
using BidConReport.Shared.DTOs.EstimationView;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BidConReport.Server.Services;

public class EstimationViewTemplateService
{
    private readonly ApplicationDbContext _dbContext;
    public delegate void UpdateAction<T>(T entityToUpdate, T updateSrcEntity) where T : IEstimationViewEntity;

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
            var entity = dto.Adapt<EstimationViewTemplate>();
            await _dbContext.EstimationViewTemplates.AddAsync(entity);
        }
        else
        {
            var updateSrc = dto.Adapt<EstimationViewTemplate>();
            UpdateEstimationViewTemplate(existing, updateSrc);
        }
        await _dbContext.SaveChangesAsync();
    }

    private void UpdateEstimationViewTemplate(EstimationViewTemplate existing, EstimationViewTemplate updateSrc)
    {
        existing.Name = updateSrc.Name;

        UpdateEstimationViewEntityList(existing.HeaderOrFooters, updateSrc.HeaderOrFooters, UpdateHeaderOrFooter);
        UpdateNetSheetSectionTemplate(existing.NetSheetSectionTemplate, updateSrc.NetSheetSectionTemplate);
        UpdateEstimationViewEntityList(existing.DataSectionTemplates, updateSrc.DataSectionTemplates, UpdateDataSectionTemplate);
        
        _dbContext.Update(existing);
    }
    private void UpdateHeaderOrFooter(HeaderOrFooter existing, HeaderOrFooter updateSrc)
    {
        existing.Value = updateSrc.Value;
        existing.Position = updateSrc.Position;
    }

    private void UpdateDataSectionTemplate(DataSectionTemplate existing, DataSectionTemplate updateSrc)
    {
        existing.Order = updateSrc.Order;
        existing.RowCount = updateSrc.RowCount;
        UpdateEstimationViewEntityList(existing.Cells, updateSrc.Cells, UpdateDataSectionCells);
        UpdateEstimationViewEntityList(existing.Columns, updateSrc.Columns, UpdateDataColumn);
    }

    private void UpdateDataColumn(DataColumn existing, DataColumn updateSrc)
    {
        existing.Order = updateSrc.Order;
        existing.WidthPercent = updateSrc.WidthPercent;
    }

    private void UpdateDataSectionCells(CellTemplate existing, CellTemplate updateSrc)
    {
        existing.Value = updateSrc.Value;
        existing.Row = updateSrc.Row;
        existing.Column = updateSrc.Column;
        UpdateCellFormat(existing.Format, updateSrc.Format);
    }

    private void UpdateCellFormat(CellFormat existing, CellFormat updateSrc)
    {
        existing.Align = updateSrc.Align;
        existing.Bold = updateSrc.Bold;
        existing.BorderBottom = updateSrc.BorderBottom;
        existing.BorderLeft = updateSrc.BorderLeft;
        existing.BorderRight = updateSrc.BorderRight;
        existing.BorderTop = updateSrc.BorderTop;
        existing.DecimalCount = updateSrc.DecimalCount;
        existing.FontFamily = updateSrc.FontFamily;
        existing.FontSize = updateSrc.FontSize;
        existing.FormatType = updateSrc.FormatType;
        existing.IncludeTimeOfDay = updateSrc.IncludeTimeOfDay;
        existing.Italic = updateSrc.Italic;
        existing.Justify = updateSrc.Justify;
        existing.Style = updateSrc.Style;
        existing.ThoasandsSeparator = updateSrc.ThoasandsSeparator;
        existing.Underline = updateSrc.Underline;
    }

    private void UpdateNetSheetSectionTemplate(NetSheetSectionTemplate? existing, NetSheetSectionTemplate? updateSrc)
    {
        if (existing is null)
        {
            existing = updateSrc;
            return;
        }
        if (updateSrc is null)
        {
            existing = updateSrc;
            return;
        }
        existing.Order = updateSrc.Order;
        UpdateEstimationViewEntityList(existing.Columns, updateSrc.Columns, UpdateSheetColumn);
    }

    private void UpdateSheetColumn(SheetColumn existing, SheetColumn updateSrc)
    {
        existing.Order = updateSrc.Order;
        existing.WidthPercent = updateSrc.WidthPercent;
        existing.ColumnType = updateSrc.ColumnType;
        UpdateCellFormat(existing.CellFormat, updateSrc.CellFormat);
    }
    private void UpdateEstimationViewEntityList<T>(ICollection<T> existing, ICollection<T> updateSrc, UpdateAction<T> updateAction) where T : IEstimationViewEntity
    {
        var toRemove = existing.Where(e => updateSrc.Select(u => u.Id).Contains(e.Id) == false);
        var toUpdate = existing.Where(e => updateSrc.Select(u => u.Id).Contains(e.Id));
        var toAdd = updateSrc.Where(u => existing.Select(e => e.Id).Contains(u.Id) == false);
        foreach (var entityToRemove in toRemove)
        {
            existing.Remove(entityToRemove);
        }
        foreach (var entityToAdd in toAdd)
        {
            existing.Add(entityToAdd);
        }
        foreach (var entityToUpdate in toUpdate)
        {   
            var updateSrcEntity = updateSrc.First(x => x.Id == entityToUpdate.Id);
            updateAction.Invoke(entityToUpdate, updateSrcEntity);
        }
    }
}
