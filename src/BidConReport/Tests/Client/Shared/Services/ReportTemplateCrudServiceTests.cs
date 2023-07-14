using System.Net;
using System.Text.Json;
using Azure;
using BidConReport.Shared.Constants;
using BidConReport.Shared.Features.ReportTemplate;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using SharedPlatformLibrary.Wrappers;

namespace BidConReport.Client.Shared.Services.Tests
{
    
    [TestFixture]
    public class ReportTemplateCrudServiceTests
    {
        private ReportTemplateCrudService? _reportTemplateCrudService;
        private Mock<IHttpClientWrapper>? _httpClientWrapperMock;
        [SetUp]
        public void SetUp()
        {
            _httpClientWrapperMock = new Mock<IHttpClientWrapper>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger<ReportTemplateCrudService>>();
            _reportTemplateCrudService = new ReportTemplateCrudService(_httpClientWrapperMock.Object, loggerMock.Object);
        }
        private ReportTemplate GetSampleData()
        {
            var jsonFIlePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ReportTemplateSample.json");
            var jsonData = File.ReadAllText(jsonFIlePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ReportTemplate>(jsonData, options)!;
        }
        [Test]
        public async Task UpsertAsync_ShouldCallPostAsJsonAsyncWithCorrectDataAndUri()
        {
            // Arrange
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.Upsert;
            var expectedData = GetSampleData();

            _httpClientWrapperMock!
                .Setup(x => x.PostAsJsonAsync(expectedUri, expectedData, CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            // Act
            await _reportTemplateCrudService!.UpsertAsync(expectedData);

            // Assert
            _httpClientWrapperMock!.Verify(x => x.PostAsJsonAsync(expectedUri, expectedData, CancellationToken.None), Times.Once);
        }
        [Test]
        public async Task GetAllAsync_ShouldCallGetAsyncAndReturnListOfReportTemplates()
        {
            // Arrange
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.All;
            var expectedReportTemplates = new List<ReportTemplate> { GetSampleData() };

            _httpClientWrapperMock!
                .Setup(x => x.GetAsync(expectedUri, CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expectedReportTemplates)),
                });

            // Act
            var result = await _reportTemplateCrudService!.GetAllAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedReportTemplates.Count));
            foreach (var item in result)
            {
                Assert.That(expectedReportTemplates.Any(x => x.Id == item.Id), Is.True);
            }
            _httpClientWrapperMock.Verify(x => x.GetAsync(expectedUri, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task GetDefaultAsync_ShouldCallGetAsyncWithCorrectUriAndReturnCorrectData()
        {
            // Arrange
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.Default;
            var expectedData =  GetSampleData();

            _httpClientWrapperMock!
                .Setup(x => x.GetAsync(expectedUri, CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expectedData)),
                });

            // Act
            var result = await _reportTemplateCrudService!.GetDefaultAsync();

            // Assert
            Assert.That(result?.Id, Is.EqualTo(expectedData.Id));
            _httpClientWrapperMock!.Verify(c => c.GetAsync(expectedUri, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task SetAsDefaultAsync_ShouldCallPostAsJsonAsyncWithCorrectDataAndUri()
        {
            // Arrange
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.SetDefault;
            var expectedData = GetSampleData();

            _httpClientWrapperMock!
                .Setup(x => x.PostAsJsonAsync(expectedUri, expectedData, CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });

            // Act
           await _reportTemplateCrudService!.SetAsDefaultAsync(expectedData);

            // Assert
            _httpClientWrapperMock.Verify(c => c.PostAsJsonAsync(expectedUri, expectedData, CancellationToken.None), Times.Once);
        }
        [Test]
        public async Task DeleteAsync_ShouldCallDeleteAsyncWithCorrectUri()
        {
            // Arrange
            var id = 123; // Sample report template ID
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.Delete + id.ToString();
            _httpClientWrapperMock!
                .Setup(x => x.DeleteAsync(expectedUri, CancellationToken.None))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                });
            // Act
            await _reportTemplateCrudService!.DeleteAsync(id);

            // Assert
            _httpClientWrapperMock.Verify(c => c.DeleteAsync(expectedUri, CancellationToken.None), Times.Once);
        }
    }
}
