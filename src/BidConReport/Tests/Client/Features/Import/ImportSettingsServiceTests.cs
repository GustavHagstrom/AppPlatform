using BidConReport.Client.Features.Import.Services;
using BidConReport.Shared.Constants;
using BidConReport.Shared.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BidConReport.Client.Tests.Features.Import.Services
{
    [TestFixture]
    public class ImportSettingsServiceTests
    {
        private Mock<IHttpClientFactory> _httpClientFactoryMock;
        private Mock<ILogger<ImportSettingsService>> _loggerMock;
        private ImportSettingsService _importSettingsService;
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;

        [SetUp]
        public void Setup()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _loggerMock = new Mock<ILogger<ImportSettingsService>>();
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient(_httpMessageHandlerMock.Object));
            _importSettingsService = new ImportSettingsService(_httpClientFactoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task DeleteAsync_ShouldSendDeleteRequestWithCorrectUrl()
        {
            // Arrange
            int settingsId = 1;
            var expectedUrl = $"{BackendApiEndpoints.ImportEndpoints.Delete}/{settingsId}";
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Delete && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            await _importSettingsService.DeleteAsync(settingsId);

            // Assert
            _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Delete && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task GetAllAsync_ShouldSendGetRequestWithCorrectUrlAndReturnSettings()
        {
            // Arrange
            var expectedUrl = BackendApiEndpoints.ImportEndpoints.All;
            var settings = new List<EstimationImportSettings>();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent(typeof(ICollection<EstimationImportSettings>), settings, new JsonMediaTypeFormatter())
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _importSettingsService.GetAllAsync();

            // Assert
            _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
            Assert.AreEqual(settings, result);
        }

        [Test]
        public async Task GetDefaultAsync_ShouldSendGetRequestWithCorrectUrlAndReturnSettings()
        {
            // Arrange
            var expectedUrl = BackendApiEndpoints.ImportEndpoints.Default;
            var settings = new EstimationImportSettings();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent(typeof(EstimationImportSettings), settings, new JsonMediaTypeFormatter())
            };
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _importSettingsService.GetDefaultAsync();

            // Assert
            _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
            Assert.AreEqual(settings, result);
        }

        [Test]
        public async Task SaveAsDefaultAsync_ShouldSendPostRequestWithCorrectUrlAndContent()
        {
            // Arrange
            var expectedUrl = BackendApiEndpoints.ImportEndpoints.SetDefault;
            var settings = new EstimationImportSettings();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            await _importSettingsService.SaveAsDefaultAsync(settings);

            // Assert
            _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task UpsertAsync_ShouldSendPostRequestWithCorrectUrlAndContent()
        {
            // Arrange
            var expectedUrl = BackendApiEndpoints.ImportEndpoints.Upsert;
            var settings = new EstimationImportSettings();
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            await _importSettingsService.UpsertAsync(settings);

            // Assert
            _httpMessageHandlerMock.Protected().Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString() == expectedUrl), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task UpsertAsync_ShouldHandleHttpRequestException()
        {
            // Arrange
            var expectedExceptionMessage = "An error occurred while saving import setting.";
            var settings = new EstimationImportSettings();
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed."));

            try
            {
                // Act
                await _importSettingsService.UpsertAsync(settings);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<HttpRequestException>(ex.InnerException);
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldHandleHttpRequestException()
        {
            // Arrange
            var expectedExceptionMessage = "Failed to delete import settings: Request failed.";
            int settingsId = 1;
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed."));

            try
            {
                // Act
                await _importSettingsService.DeleteAsync(settingsId);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<Exception>(ex.InnerException);
                Assert.AreEqual("Request failed.", ex.InnerException.Message);
            }
        }

        [Test]
        public async Task GetAllAsync_ShouldHandleHttpRequestException()
        {
            // Arrange
            var expectedExceptionMessage = "Failed to retrieve import settings: Request failed.";
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed."));

            try
            {
                // Act
                await _importSettingsService.GetAllAsync();
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<Exception>(ex.InnerException);
                Assert.AreEqual("Request failed.", ex.InnerException.Message);
            }
        }

        [Test]
        public async Task GetDefaultAsync_ShouldHandleHttpRequestException()
        {
            // Arrange
            var expectedExceptionMessage = "Failed to retrieve standard import settings: Request failed.";
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed."));

            try
            {
                // Act
                await _importSettingsService.GetDefaultAsync();
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<Exception>(ex.InnerException);
                Assert.AreEqual("Request failed.", ex.InnerException.Message);
            }
        }

        [Test]
        public async Task SaveAsDefaultAsync_ShouldHandleHttpRequestException()
        {
            // Arrange
            var expectedExceptionMessage = "An error occurred while saving the standard import setting.";
            var settings = new EstimationImportSettings();
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException("Request failed."));

            try
            {
                // Act
                await _importSettingsService.SaveAsDefaultAsync(settings);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<HttpRequestException>(ex.InnerException);
                Assert.AreEqual("Request failed.", ex.InnerException.Message);
            }
        }

        [Test]
        public async Task UpsertAsync_ShouldHandleOperationCanceledException()
        {
            // Arrange
            var expectedExceptionMessage = "An error occurred while saving import setting.";
            var settings = new EstimationImportSettings();
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new OperationCanceledException());

            try
            {
                // Act
                await _importSettingsService.UpsertAsync(settings);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<OperationCanceledException>(ex.InnerException);
            }
        }

        [Test]
        public async Task UpsertAsync_ShouldHandleUnexpectedError()
        {
            // Arrange
            var expectedExceptionMessage = "An error occurred while saving import setting.";
            var settings = new EstimationImportSettings();
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new Exception("Unexpected error."));

            try
            {
                // Act
                await _importSettingsService.UpsertAsync(settings);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(expectedExceptionMessage, ex.Message);
                Assert.IsInstanceOf<Exception>(ex.InnerException);
                Assert.AreEqual("Unexpected error.", ex.InnerException.Message);
            }
        }




    }
}
