using AppPlatform.Server.EstimationViewTemplate_old.Models;
using AppPlatform.Server.EstimationViewTemplate_old.Services;
using Microsoft.Extensions.Logging;
using Moq;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.DTOs.EstimationView;
using AppPlatform.Shared.Wrappers;
using System.Net;

namespace AppPlatform.Tests.Server.EstimationViewTemplate_old;
public class EstimationViewTemplateServiceTests
{
    private EstimationViewTemplateService _estimationViewTemplateService;
    private Mock<IHttpClientWrapper> _httpClientWrapperMock;
    private Mock<ILogger<EstimationViewTemplateService>> _loggerMock;

    [SetUp]
    public void SetUp()
    {
        _httpClientWrapperMock = new Mock<IHttpClientWrapper>();
        _loggerMock = new Mock<ILogger<EstimationViewTemplateService>>();
        _estimationViewTemplateService = new EstimationViewTemplateService(_httpClientWrapperMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task UpsertAsync_Should_Succeed()
    {
        var viewTemplate = new ViewTemplate { Name = "test" };

        _httpClientWrapperMock.Setup(mock => mock.PostAsJsonAsync(BackendApiEndpoints.EstimationViewTemplateController.Upsert, It.IsAny<EstimationViewTemplateDto>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        // Act
        await _estimationViewTemplateService.UpsertAsync(viewTemplate);

        // Assert
        _httpClientWrapperMock.Verify(mock => mock.PostAsJsonAsync(BackendApiEndpoints.EstimationViewTemplateController.Upsert, It.IsAny<EstimationViewTemplateDto>(), It.IsAny<CancellationToken>()), Times.Once);
    }
    [Test]
    public void UpsertAsync_ShouldThrowException()
    {
        var viewTemplate = new ViewTemplate { Name = "test" };

        // Arrange
        _httpClientWrapperMock.Setup(mock => mock.PostAsJsonAsync(BackendApiEndpoints.EstimationViewTemplateController.Upsert, It.IsAny<EstimationViewTemplateDto>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError));

        // Act
        Assert.ThrowsAsync<HttpRequestException>(() => _estimationViewTemplateService.UpsertAsync(viewTemplate));
    }
    [Test]
    public async Task GetAllShallowAsync_ShouldReturnEmptyCollection()
    {
        var expectedResult = new List<ViewTemplate>();

        // _httpClientWrapperMock
        _httpClientWrapperMock.Setup(mock => mock.GetAsync(BackendApiEndpoints.EstimationViewTemplateController.GetShallowList, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NoContent));

        // Act
        var result = await _estimationViewTemplateService.GetAllShallowAsync();

        // Assert
        _httpClientWrapperMock.Verify(mock => mock.GetAsync(BackendApiEndpoints.EstimationViewTemplateController.GetShallowList, It.IsAny<CancellationToken>()), Times.Once);
        Assert.That(result.Count(), Is.EqualTo(0));
    }
    [Test]
    public void GetAllShallowAsync_ShouldThrowException()
    {
        var expectedResult = new List<ViewTemplate>();

        // _httpClientWrapperMock
        _httpClientWrapperMock.Setup(mock => mock.GetAsync(BackendApiEndpoints.EstimationViewTemplateController.GetShallowList, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError));

        // Assert
        Assert.ThrowsAsync<HttpRequestException>(() => _estimationViewTemplateService.GetAllShallowAsync());
    }
    [Test]
    public void Delete_ShouldThrowException()
    {
        var viewTemplate = new ViewTemplate { Name = "test" };

        // _httpClientWrapperMock
        _httpClientWrapperMock.Setup(mock => mock.DeleteAsync(BackendApiEndpoints.EstimationViewTemplateController.Delete + $"?id={viewTemplate.Id}", It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError));

        // Assert
        Assert.ThrowsAsync<HttpRequestException>(() => _estimationViewTemplateService.DeleteAsync(viewTemplate));
        _httpClientWrapperMock.Verify(mock => mock.DeleteAsync(BackendApiEndpoints.EstimationViewTemplateController.Delete + $"?id={viewTemplate.Id}", It.IsAny<CancellationToken>()), Times.Once);
        
    }
    [Test]
    public void Get_ShouldThrowException()
    {
        var guid = Guid.NewGuid();
        var requestUri = BackendApiEndpoints.EstimationViewTemplateController.Get + $"?id={guid}";

        // _httpClientWrapperMock
        _httpClientWrapperMock.Setup(mock => mock.GetAsync(requestUri, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.InternalServerError));

        // Assert
        Assert.ThrowsAsync<HttpRequestException>(() => _estimationViewTemplateService.GetAsync(guid));
        _httpClientWrapperMock.Verify(mock => mock.GetAsync(requestUri, It.IsAny<CancellationToken>()), Times.Once);

    }

}
