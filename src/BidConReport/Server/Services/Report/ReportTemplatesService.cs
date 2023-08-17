using BidConReport.Server.Data;
using BidConReport.Server.Enteties.Report;
using BidConReport.Shared.DTOs.ReportTemplate;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BidConReport.Server.Services.Report;

public class ReportTemplatesService : IReportTemplatesService
{
    private readonly ApplicationDbContext _dbContext;

    public ReportTemplatesService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task UpsertAsync(string userId, int organizationId, ReportTemplateDto dto)
    {
        dto.OrganizationId = organizationId;
        var result = await FirstOrDefaultAsync_IncludAll(x => x.Id == dto.Id);

        if (result == null)
        {
            await _dbContext.ReportTemplates.AddAsync(dto.Adapt<ReportTemplate>());
        }
        else
        {
            dto.Adapt(result);
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task<ICollection<ReportTemplateDto>> GetAllOrganizationTemplatesAsync(int organizationId)
    {
        var result = await ToListAsync_IncludAll(x => x.OrganizationId == organizationId);

        return result.Select(x => x.Adapt<ReportTemplateDto>()).ToList();
    }
    public async Task<ReportTemplateDto?> GetDefaultAsync(string userId, int organizationId)
    {
        var userOrg = await _dbContext.UserOrganizations.FirstAsync(x => x.UserId == userId && x.OrganizationId == organizationId);
        ArgumentNullException.ThrowIfNull(userOrg);
        if (userOrg.DefaultReportTemplateId is null)
        {
            return null;
        }
        else
        {
            var result = await FirstOrDefaultAsync_IncludAll(x => x.Id == userOrg.DefaultReportTemplateId);
            return result is null ? null : result.Adapt<ReportTemplateDto>();
        }
    }
    public async Task DeleteAsync(int templateId, string userId, int organizationId)
    {
        var userOrg = await _dbContext.UserOrganizations.FirstAsync(x => x.UserId == userId && x.OrganizationId == organizationId);
        var template = await FirstOrDefaultAsync_IncludAll(x => x.Id == templateId);
        ArgumentNullException.ThrowIfNull(userOrg);
        ArgumentNullException.ThrowIfNull(template);
        if (template.OrganizationId == userOrg.OrganizationId)
        {
            _dbContext.Remove(template);

            _dbContext.Remove(template.TopLeftHeader);
            _dbContext.Remove(template.TopRightHeader);
            _dbContext.Remove(template.TitleSection);
            _dbContext.Remove(template.InformationSection);
            _dbContext.Remove(template.PriceSection);
            _dbContext.Remove(template.TableSection);

            _dbContext.Remove(template.TopLeftHeader.Font);
            _dbContext.Remove(template.TopRightHeader.Font);

            _dbContext.Remove(template.TitleSection.Font);

            _dbContext.Remove(template.InformationSection.TitleFont);
            _dbContext.Remove(template.InformationSection.ValueFont);

            _dbContext.Remove(template.PriceSection.CommentFont);
            _dbContext.Remove(template.PriceSection.PriceFont);

            _dbContext.Remove(template.TableSection.CellFont);
            _dbContext.Remove(template.TableSection.PartFont);
            _dbContext.Remove(template.TableSection.GroupFont);
        }
        await _dbContext.SaveChangesAsync();
    }
    public async Task SetAsDefaultAsync(string userId, int organizationId, int templateId)
    {
        var userOrg = await _dbContext.UserOrganizations.FirstOrDefaultAsync(x => x.UserId == userId && x.OrganizationId == organizationId);
        var template = await _dbContext.ReportTemplates.FindAsync(templateId);
        ArgumentNullException.ThrowIfNull(userOrg);
        ArgumentNullException.ThrowIfNull(template);

        if (template.OrganizationId != organizationId)
        {
            return;
        }
        userOrg.DefaultReportTemplateId = templateId;
        await _dbContext.SaveChangesAsync();
    }
    private async Task<ReportTemplate?> FirstOrDefaultAsync_IncludAll(Expression<Func<ReportTemplate, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.ReportTemplates
            .Include(x => x.TopLeftHeader).ThenInclude(x => x.Font)
            .Include(x => x.TopRightHeader).ThenInclude(x => x.Font)
            .Include(x => x.TitleSection).ThenInclude(x => x.Font)
            .Include(x => x.InformationSection).ThenInclude(x => x.TitleFont)
            .Include(x => x.InformationSection).ThenInclude(x => x.ValueFont)
            .Include(x => x.InformationSection).ThenInclude(x => x.Items)
            .Include(x => x.PriceSection).ThenInclude(x => x.CommentFont)
            .Include(x => x.PriceSection).ThenInclude(x => x.PriceFont)
            .Include(x => x.TableSection).ThenInclude(x => x.Columns)
            .Include(x => x.TableSection).ThenInclude(x => x.CellFont)
            .Include(x => x.TableSection).ThenInclude(x => x.GroupFont)
            .Include(x => x.TableSection).ThenInclude(x => x.PartFont)
            .Include(x => x.TableSection).ThenInclude(x => x.ColumnHeaderFont)
            .FirstOrDefaultAsync(predicate);

        return result;
    }
    private async Task<ICollection<ReportTemplate>> ToListAsync_IncludAll(Expression<Func<ReportTemplate, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.ReportTemplates
            .Include(x => x.TopLeftHeader).ThenInclude(x => x.Font)
            .Include(x => x.TopRightHeader).ThenInclude(x => x.Font)
            .Include(x => x.TitleSection).ThenInclude(x => x.Font)
            .Include(x => x.InformationSection).ThenInclude(x => x.TitleFont)
            .Include(x => x.InformationSection).ThenInclude(x => x.ValueFont)
            .Include(x => x.InformationSection).ThenInclude(x => x.Items)
            .Include(x => x.PriceSection).ThenInclude(x => x.CommentFont)
            .Include(x => x.PriceSection).ThenInclude(x => x.PriceFont)
            .Include(x => x.TableSection).ThenInclude(x => x.Columns)
            .Include(x => x.TableSection).ThenInclude(x => x.CellFont)
            .Include(x => x.TableSection).ThenInclude(x => x.GroupFont)
            .Include(x => x.TableSection).ThenInclude(x => x.PartFont)
            .Include(x => x.TableSection).ThenInclude(x => x.ColumnHeaderFont)
            .Where(predicate)
            .ToListAsync();

        return result;
    }

}

