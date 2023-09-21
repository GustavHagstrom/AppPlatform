using Client.Shared.EstimationViewTemplate.Models;
using Client.Shared.EstimationViewTemplate.Services;
using Microsoft.Extensions.Logging;
using Moq;
using SharedLibrary.Wrappers;
using System.Net;

namespace Tests.Client.Shared.EstimationViewTemplate;
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
        var viewTemplate = new ViewTemplate { Name = "test"};
        var cancellationToken = CancellationToken.None;

        // Arrange
        _httpClientWrapperMock.Setup(mock => mock.PostAsJsonAsync(It.IsAny<string>(), viewTemplate, cancellationToken))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        // Act
        await _estimationViewTemplateService.UpsertAsync(viewTemplate, cancellationToken);

        // Assert
        _httpClientWrapperMock.Verify(mock => mock.PostAsJsonAsync(It.IsAny<string>(), viewTemplate, cancellationToken), Times.Once);
    }

    [Test]
    public async Task DeleteAsync_Should_Succeed()
    {
        var viewTemplate = new ViewTemplate { Name = "test" };
        var cancellationToken = CancellationToken.None;

        // Arrange
        _httpClientWrapperMock.Setup(mock => mock.DeleteAsync(It.IsAny<string>(), viewTemplate, cancellationToken))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

        // Act
        await _estimationViewTemplateService.DeleteAsync(viewTemplate, cancellationToken);

        // Assert
        _httpClientWrapperMock.Verify(mock => mock.DeleteAsync(It.IsAny<string>(), viewTemplate, cancellationToken), Times.Once);
    }

    [Test]
    public async Task GetAsync_Should_Succeed()
    {
        var id = Guid.NewGuid();
        var cancellationToken = CancellationToken.None;
        var expectedResult = new ViewTemplate();

        // Arrange
        _httpClientWrapperMock.Setup(mock => mock.GetAsync<ViewTemplate>(It.IsAny<string>(), id, cancellationToken))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _estimationViewTemplateService.GetAsync(id, cancellationToken);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public async Task GetAllShallowAsync_Should_Succeed()
    {
        var cancellationToken = CancellationToken.None;
        var expectedResult = new List<ViewTemplate>();

        // Arrange
        _httpClientWrapperMock.Setup(mock => mock.GetAsync<List<ViewTemplate>>(It.IsAny<string>(), cancellationToken))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _estimationViewTemplateService.GetAllShallowAsync(cancellationToken);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }
}
