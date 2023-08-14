using BidConReport.Shared.Constants;
using Microsoft.Extensions.Logging;
using SharedPlatformLibrary.DTOs;
using SharedPlatformLibrary.Wrappers;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<OrganizationService> _logger;

    public OrganizationService(IHttpClientWrapper httpClient, ILogger<OrganizationService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task CreateNew(OrganizationDTO organization)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.OrganizationsController.Create, organization);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error when creating new organization");
            throw;
        }
    }

    public async Task<ICollection<OrganizationDTO>> GetAll()
    {
        try
        {
            var response = await _httpClient.GetAsync(BackendApiEndpoints.OrganizationsController.GetAll);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ICollection<OrganizationDTO>>();
            return result ?? throw new Exception("Response was null");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error when requesting all user Organizations");
            throw;
        }
    }

    public async Task<OrganizationDTO?> GetCurrent()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<OrganizationDTO>(BackendApiEndpoints.OrganizationsController.GetCurrent);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error when requesting currently active user Organizations");
            throw;
        }
    }

    public async Task SetAsActive(OrganizationDTO organization)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.OrganizationsController.SetAsCurrent, organization);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error when setting currently active user Organization");
            throw;
        }
    }
}
