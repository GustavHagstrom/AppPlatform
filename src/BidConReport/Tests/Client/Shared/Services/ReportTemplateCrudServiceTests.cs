using System.Net;
using System.Text.Json;
using BidConReport.Shared.Constants;
using BidConReport.Shared.Features.ReportTemplate;
using Moq;

namespace BidConReport.Client.Shared.Services.Tests
{
    [TestFixture]
    public class ReportTemplateCrudServiceTests
    {
        private Mock<HttpClient> _mockHttpClient;
        private IReportTemplateCrudService _reportTemplateCrudService;

        [SetUp]
        public void Setup()
        {
            _mockHttpClient = new Mock<HttpClient>();
            _reportTemplateCrudService = new ReportTemplateCrudService(_mockHttpClient.Object);
        }
        private ReportTemplate GetSampleData()
        {
            var jsonFIlePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ReportTemplateSample.json");
            var jsonData = File.ReadAllText(jsonFIlePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ReportTemplate>(jsonData, options)!;
        }
        [Test]
        public async Task GetAll_ShouldReturnListOfReportTemplates()
        {
            // Arrange
            var sample = GetSampleData();
            var expectedReportTemplates = new List<ReportTemplate> { sample };
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedReportTemplates))
            };
            _mockHttpClient.Setup(c => c.GetAsync(BackendApiEndpoints.ReportTemplatesController.All))
                .ReturnsAsync(response);

            // Act
            var result = await _reportTemplateCrudService.GetAll();

            // Assert
            Assert.That(result.Count, Is.EqualTo(expectedReportTemplates.Count));
            foreach (var item in result)
            {
                Assert.That(expectedReportTemplates.Any(x => x.Id == item.Id));
            }
        }
        [Test]
        public async Task GetAll_ShouldCallHttpClientGetAsyncWithCorrectUri()
        {
            // Arrange
            var expectedUri = BackendApiEndpoints.ReportTemplatesController.All;
            //var sample = GetSampleData();
            //var expectedReportTemplates = new List<ReportTemplate> { sample };
            //var response = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new StringContent(JsonSerializer.Serialize(expectedReportTemplates))
            //};
            //_mockHttpClient.Setup(c => c.GetAsync(BackendApiEndpoints.ReportTemplatesController.All))
            //    .ReturnsAsync(response);

            // Act
            await _reportTemplateCrudService.GetAll();

            // Assert
            _mockHttpClient.Verify(c => c.GetAsync(expectedUri, CancellationToken.None), Times.Once);
        }

        //[Test]
        //public async Task Create_ShouldCallHttpClientPostAsyncWithCorrectData()
        //{
        //    // Arrange
        //    var reportTemplate = new ReportTemplate { /* Populate with sample data */ };
        //    var expectedUri = "api/reporttemplates";
        //    var expectedContent = new StringContent(JsonConvert.SerializeObject(reportTemplate));

        //    // Act
        //    await _reportTemplateCrudService.Create(reportTemplate);

        //    // Assert
        //    _mockHttpClient.Verify(c => c.PostAsync(expectedUri, expectedContent, CancellationToken.None), Times.Once);
        //}

        //[Test]
        //public async Task Get_ShouldCallHttpClientGetAsyncWithCorrectUri()
        //{
        //    // Arrange
        //    var id = 123; // Sample report template ID
        //    var expectedUri = $"api/reporttemplates/{id}";

        //    // Act
        //    await _reportTemplateCrudService.Get(id);

        //    // Assert
        //    _mockHttpClient.Verify(c => c.GetAsync(expectedUri, CancellationToken.None), Times.Once);
        //}

        //[Test]
        //public async Task GetDefault_ShouldCallHttpClientGetAsyncWithCorrectUri()
        //{
        //    // Arrange
        //    var expectedUri = "api/reporttemplates/default";

        //    // Act
        //    await _reportTemplateCrudService.GetDefault();

        //    // Assert
        //    _mockHttpClient.Verify(c => c.GetAsync(expectedUri, CancellationToken.None), Times.Once);
        //}

        //[Test]
        //public async Task Update_ShouldCallHttpClientPutAsyncWithCorrectData()
        //{
        //    // Arrange
        //    var reportTemplate = new ReportTemplate { /* Populate with sample data */ };
        //    var expectedUri = $"api/reporttemplates/{reportTemplate.Id}";
        //    var expectedContent = new StringContent(JsonConvert.SerializeObject(reportTemplate));

        //    // Act
        //    await _reportTemplateCrudService.Update(reportTemplate);

        //    // Assert
        //    _mockHttpClient.Verify(c => c.PutAsync(expectedUri, expectedContent, CancellationToken.None), Times.Once);
        //}

        //[Test]
        //public void Delete_ShouldCallHttpClientDeleteAsyncWithCorrectUri()
        //{
        //    // Arrange
        //    var id = 123; // Sample report template ID
        //    var expectedUri = $"api/reporttemplates/{id}";

        //    // Act
        //    _reportTemplateCrudService.Delete(id);

        //    // Assert
        //    _mockHttpClient.Verify(c => c.DeleteAsync(expectedUri, CancellationToken.None), Times.Once);
        //}
    }
}
