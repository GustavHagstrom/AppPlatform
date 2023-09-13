using BidConReport.Server.Data;
using BidConReport.Server.Services;
using BidConReport.Shared.DTOs.EstimationView;
using BidConReport.Shared.Enums.ViewTemplate;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BidconReport.Tests.Server.Services;
[TestFixture]
public class EstimationViewTemplateServiceTests
{
    private TestDbContext _dbContext;
    private EstimationViewTemplateService _service;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb" + TestContext.CurrentContext.Test.Name)
            .Options;

        _dbContext = new TestDbContext(options);
        _service = new EstimationViewTemplateService(_dbContext);
    }
    private EstimationViewTemplateDto Sample()
    {
        var entety = new EstimationViewTemplateDto
        {
            Name = "Test",
            DataSectionTemplates =
            {
                new DataSectionTemplateDto
                {
                    Order = 1,
                    Columns =
                    {
                        new DataColumnDto
                        {
                            WidthPercent = 100,
                            Order = 1,
                        }
                    },
                    Cells =
                    {
                        new CellTemplateDto
                        {
                            Column = 1,
                            Format = new CellFormatDto
                            {
                                FontFamily = "Calibri"
                            }
                        }
                    },
                    RowCount = 1,
                }
            },
            HeaderOrFooters =
            {
                new HeaderOrFooterDto
                {
                    Position = HeaderOrFooterPosition.TopLeft,
                    Value = "TopLeft Header"
                }
            },
            NetSheetSectionTemplate = new NetSheetSectionTemplateDto
            {
                Order = 2,
                Columns =
                {
                    new SheetColumnDto
                    {
                        Order = 1,
                        ColumnType = SheetColumnType.Description,
                        CellFormat = new CellFormatDto
                        {
                            FontFamily = "Calibri"
                        }
                    }
                },
            }
        };
        return entety;
    }
    [Test]
    public async Task UpsertAsync_ShouldInsertNewRecordWithNestedValues()
    {
        var entety = Sample();

        await _service.UpsertAsync(entety);
        var actual = await _dbContext.EstimationViewTemplates
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync();

        Assert.That(actual, Is.Not.Null);
        Assert.That(actual.HeaderOrFooters.Count, Is.EqualTo(1));
        Assert.That(actual?.NetSheetSectionTemplate?.Columns.Count, Is.EqualTo(1));
        Assert.That(actual.NetSheetSectionTemplate.Columns.First().CellFormat, Is.Not.Null);
        Assert.That(actual?.DataSectionTemplates?.Count, Is.EqualTo(1));
        Assert.That(actual.DataSectionTemplates.First().Cells.Count, Is.EqualTo(1));
        Assert.That(actual.DataSectionTemplates.First().Columns.Count, Is.EqualTo(1));
        Assert.That(actual.DataSectionTemplates.First().Cells.First().Format, Is.Not.Null);
        Assert.That(actual.DataSectionTemplates.First().Columns.FirstOrDefault(), Is.Not.Null);
    }
    [Test]
    public async Task UpsertAsync_ShouldUpdateIncludingNested()
    {
        //TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        var entity = Sample();
        await _service.UpsertAsync(entity);
        var dbEntety = await _dbContext.EstimationViewTemplates
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync();
        var dto = dbEntety!.Adapt<EstimationViewTemplateDto>();
        //.Adapt(entity);
        dto.DataSectionTemplates.First().Cells.First().Format.FontFamily = "Arial";

        await _service.UpsertAsync(dto);
        var actual = await _dbContext.EstimationViewTemplates
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync();

        
        Assert.That(actual?.DataSectionTemplates.First().Cells.First().Format.FontFamily, Is.EqualTo("Arial"));
    }
}
