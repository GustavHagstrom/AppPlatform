﻿using BidConReport.Server.Data;
using BidConReport.Server.Enteties;
using BidConReport.Server.Enteties.Report;
using BidConReport.Server.Services.Report;
using BidConReport.Shared.DTOs.ReportTemplate;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BidconReport.Tests.Server.Features.Report;
[TestFixture]
public class ReportTemplatesCrudServiceTests
{
    private TestDbContext _dbContext;
    private ReportTemplatesService _service;
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
        _dbContext.ReportTemplates.Add(SampleTemaplte(1, "Default", _orgId).Adapt<ReportTemplate>());
        _dbContext.ReportTemplates.Add(SampleTemaplte(2, "Option", _orgId).Adapt<ReportTemplate>());
        _dbContext.ReportTemplates.Add(SampleTemaplte(3, "OtherOrgTemplate", "orgId2").Adapt<ReportTemplate>());
        _dbContext.SaveChanges();

        _service = new ReportTemplatesService(_dbContext);
    }
    private ReportTemplateDto SampleTemaplte(int id, string name, string orgId)
    {
        return new ReportTemplateDto
        {
            Id = id,
            Name = name,
            OrganizationId = orgId,
            
            TopLeftHeader = new HeaderDefinitionDto()
            {
                Font = new FontPropertiesDto() { FontFamily = string.Empty },
                ValueCode = string.Empty,
            },
            TopRightHeader = new HeaderDefinitionDto()
            {
                Font = new FontPropertiesDto() { FontFamily = string.Empty },
                ValueCode = string.Empty,
            },
            TitleSection = new TitleSectionDto()
            {
                Font = new FontPropertiesDto() { FontFamily = string.Empty },
            },
            InformationSection = new InformationSectionDto()
            {
                Items = new(),
                TitleFont = new FontPropertiesDto() { FontFamily = string.Empty },
                ValueFont = new FontPropertiesDto() { FontFamily = string.Empty },
            },
            PriceSection = new PriceSectionDto()
            {
                CommentFont = new FontPropertiesDto() { FontFamily = string.Empty },
                PriceFont = new FontPropertiesDto() { FontFamily = string.Empty },
            },
            TableSection = new TableSectionDto()
            {
                CellFont = new FontPropertiesDto() { FontFamily = string.Empty },
                ColumnHeaderFont = new FontPropertiesDto() { FontFamily = string.Empty },
                GroupFont = new FontPropertiesDto() { FontFamily = string.Empty },
                PartFont = new FontPropertiesDto() { FontFamily = string.Empty },
                Columns = new(),
            },
        };
    }
    [Test]
    public async Task UpsertAsync_ShouldCreateNewIncludingNestedObjects()
    {
        //Arrange
        var expectedReportTemplate = SampleTemaplte(4, "newTemplate", _orgId);

        //Act
        await _service.UpsertAsync(_userId, _orgId, expectedReportTemplate);
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
        //var expectedReportTemplate = SampleTemaplte(3, "updatedTemplate", _orgId);
        var original = await _dbContext.ReportTemplates.FindAsync(3);
        var expectedDto = original!.Adapt<ReportTemplateDto>();
        expectedDto.Name = "updatedTemplate";

        //Act
        await _service.UpsertAsync(_userId, _orgId, expectedDto);
        var result = await _dbContext.ReportTemplates.FirstOrDefaultAsync(x => x.Id == 3);

        //Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(expectedDto.Id));
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
        var result = await _service.GetDefaultAsync(_userId, _orgId);

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
        await _service.DeleteAsync(2, _userId, _orgId);
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
        await _service.DeleteAsync(3, _userId, _orgId);
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
        await _service.SetAsDefaultAsync(_userId, _orgId, expectedTemplateId);
        var actualUserOrg = _dbContext.UserOrganizations.FirstOrDefault(x => x.UserId == _userId);

        //Assert
        Assert.That(actualUserOrg, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(actualUserOrg.DefaultReportTemplateId, Is.EqualTo(expectedTemplateId));
        });
    }

}
