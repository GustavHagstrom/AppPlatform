﻿using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs.ReportTemplate;
using SharedPlatformLibrary.Wrappers;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services
{
    public class ReportTemplateService : IReportTemplateService
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly ILogger<ReportTemplateService> _logger;

        public ReportTemplateService(IHttpClientWrapper httpClient, ILogger<ReportTemplateService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task UpsertAsync(ReportTemplateDto reportTemplate)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.ReportTemplatesController.Upsert, reportTemplate);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while performing UpsertAsync");
                throw;
            }
        }

        public async Task<ICollection<ReportTemplateDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BackendApiEndpoints.ReportTemplatesController.All);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<ICollection<ReportTemplateDto>>();
                return data ?? Array.Empty<ReportTemplateDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while performing GetAllAsync");
                throw;
            }
        }

        public async Task<ReportTemplateDto?> GetDefaultAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BackendApiEndpoints.ReportTemplatesController.Default);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadFromJsonAsync<ReportTemplateDto>();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while performing GetDefaultAsync");
                return null;
            }
        }

        public async Task SetAsDefaultAsync(ReportTemplateDto? reportTemplate)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.ReportTemplatesController.SetDefault, reportTemplate);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while performing SetAsDefaultAsync");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{BackendApiEndpoints.ReportTemplatesController.Delete}/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while performing DeleteAsync");
                throw;
            }
        }
    }
}
