using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Services.Settings;

public class OrganizationService_debug : IOrganizationService
{
    private static List<OrganizationDTO> Organizations { get; } = new List<OrganizationDTO>
    {
        new OrganizationDTO { Id = "debug_organizationId", Name = "debug_organizationName" },
        new OrganizationDTO { Id = "debug_organizationId_2", Name = "debug_organizationName2" },
    };
    public OrganizationDTO CurrentOrganization { get; set; } = Organizations.First();

    public Task CreateNew(string userId, OrganizationDTO organization)
    {
        return Task.Run(() => Organizations.Add(organization));
    }
    public async Task<ICollection<OrganizationDTO>> GetAll(string userId)
    {
        return await Task.FromResult(Organizations);
    }
    public async Task<OrganizationDTO?> GetCurrent(string userId)
    {
        return await Task.FromResult(CurrentOrganization);
    }
    public async Task SetAsActive(string userId, OrganizationDTO organization)
    {
        await Task.Run(() => CurrentOrganization = organization);
    }
}
