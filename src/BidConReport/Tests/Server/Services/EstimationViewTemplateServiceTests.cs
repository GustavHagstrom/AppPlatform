using BidConReport.Server.Controllers;
using BidConReport.Server.Data;
using BidConReport.Server.Services.EstimationView;
using BidConReport.Shared.DTOs.EstimationView;
using BidConReport.Shared.Enums.ViewTemplate;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BidconReport.Tests.Server.Services;
[TestFixture]
public class EstimationViewTemplateServiceTests
{
    private TestDbContext _dbContext;
    private IEstimationViewTemplateService _service;
    private readonly string _organizationId = "orgId";

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb" + TestContext.CurrentContext.Test.Name)
            .Options;

        var loggerMock = new Mock<ILogger<IEstimationViewTemplateService>>();

        _dbContext = new TestDbContext(options);
        _service = new EstimationViewTemplateService(_dbContext, new EstimationViewTemplateUpdater(),  loggerMock.Object);
    }
    [Test]
    public async Task UpsertAsync_ShouldInsertNewRecordWithNestedValues()
    {
        var entety = EstimationViewTemplateDtoSamples.Sample();

        await _service.UpsertAsync(entety, _organizationId);
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
        var entity = EstimationViewTemplateDtoSamples.Sample();
        await _service.UpsertAsync(entity, _organizationId);
        var dbEntety = await _dbContext.EstimationViewTemplates
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync();
        var dto = dbEntety!.Adapt<EstimationViewTemplateDto>();
        dto.DataSectionTemplates.First().Cells.First().Format.FontFamily = "Arial";

        await _service.UpsertAsync(dto, _organizationId);
        var actual = await _dbContext.EstimationViewTemplates
            .Include(x => x.HeaderOrFooters)
            .Include(x => x.NetSheetSectionTemplate).ThenInclude(x => x!.Columns).ThenInclude(x => x.CellFormat)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Columns)
            .Include(x => x.DataSectionTemplates).ThenInclude(x => x.Cells).ThenInclude(x => x.Format)
            .FirstOrDefaultAsync();

        
        Assert.That(actual?.DataSectionTemplates.First().Cells.First().Format.FontFamily, Is.EqualTo("Arial"));
    }
}
