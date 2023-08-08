using BidConReport.Server.Data;
using BidConReport.Server.Features.Report;
using BidConReport.Server.Shared.Enteties;
using BidConReport.Shared.Entities.ReportTemplate;
using Microsoft.EntityFrameworkCore;

namespace BidconReport.Tests.Server.Features.Report;
[TestFixture]
public class ReportTemplatesCrudServiceTests
{
    private TestDbContext _dbContext;
    private ReportTemplatesCrudService _service;
    private readonly string _userId = "userId";
    private readonly string _orgId = "orgId";

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase" + TestContext.CurrentContext.Test.Name)
            .Options;

        _dbContext = new TestDbContext(options);

        _dbContext.Users.Add(new User { Id = _userId });
        _dbContext.UserOrganizations.Add(new UserOrganization { OrganizationId = _orgId, UserId = _userId, DefaultReportTemplateId = 1 });
        _dbContext.ReportTemplates.Add(new ReportTemplate { Id = 1, Name = "Default", OrganizationId = _orgId });
        _dbContext.ReportTemplates.Add(new ReportTemplate { Id = 2, Name = "Option", OrganizationId = _orgId });
        _dbContext.ReportTemplates.Add(new ReportTemplate { Id = 3, Name = "OtherOrgTemplate", OrganizationId = "orgId2" });
        _dbContext.SaveChanges();

        _service = new ReportTemplatesCrudService(_dbContext);
    }

    [Test]
    public async Task UpsertAsync_ShouldCreateNewIncludingNestedObjects()
    {
        //Arrange
        var expectedReportTemplate = new ReportTemplate { Id = 4, Name = "newTemplate" };

        //Act
        await _service.UpsertAsync(expectedReportTemplate);
        var result = await _dbContext.ReportTemplates.FirstOrDefaultAsync(x => x.Id == 4);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expectedReportTemplate.Id));
            Assert.That(result.TitleSection.Font, Is.Not.Null);
        });
    }
    [Test]
    public async Task UpsertAsync_ShouldUpdate()
    {
        //Arrange
        var expectedReportTemplate = new ReportTemplate { Id = 3, Name = "updatedTemplate" };

        //Act
        await _service.UpsertAsync(expectedReportTemplate);
        var result = await _dbContext.ReportTemplates.FirstOrDefaultAsync(x => x.Id == 3);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expectedReportTemplate.Id));
            Assert.That(result.Name, Is.EqualTo("updatedTemplate"));
        });
    }

    [Test]
    public async Task GetAllOrganizationTemplatesAsync_ShouldGetAllOrgTemplates()
    {
        //Arrange

        //Act
        var result = await _service.GetAllOrganizationTemplatesAsync(_orgId);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));
        foreach (var item in result)
        {
            Assert.That(item.PriceSection.PriceFont, Is.Not.Null);
        }
    }
    [Test]
    public async Task GetDefaultAsync_ShouldGetDefault()
    {
        //Arrange
        int expectedTemplateId = 1;

        //Act
        var result = await _service.GetDefaultAsync("userId");

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expectedTemplateId));
            Assert.That(result.PriceSection.PriceFont, Is.Not.Null);
        });
    }

    [Test]
    public async Task DeleteAsync_ShouldDelete()
    {
        //Arrange
        var firstCount = _dbContext.FontProperties.Count();

        //Act
        await _service.DeleteAsync(2, _userId);
        var result = await _dbContext.ReportTemplates.FirstOrDefaultAsync(x => x.Id == 2);
        var secondCount = _dbContext.FontProperties.Count();

        //Assert
        Assert.That(result, Is.Null);
        Assert.That(firstCount, Is.GreaterThan(secondCount));
    }
    [Test]
    public async Task DeleteAsync_ShouldNotDeleteOtherOrgTemplates()
    {
        //Arrange

        //Act
        await _service.DeleteAsync(3, _userId);
        var result = await _dbContext.ReportTemplates.FirstOrDefaultAsync(x => x.Id == 3);

        //Assert
        Assert.That(result, Is.Not.Null);
    }
    [Test]
    public async Task SetAsDefaultAsync_ShouldUpdateDefaultTemplate()
    {
        //Arrange
        int expectedTemplateId = 2;

        //Act
        await _service.SetAsDefaultAsync(_userId, expectedTemplateId);
        var actualUserOrg = _dbContext.UserOrganizations.FirstOrDefault(x => x.UserId == _userId);

        //Assert
        Assert.That(actualUserOrg, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actualUserOrg.DefaultReportTemplateId, Is.EqualTo(expectedTemplateId));
        });
    }

}
