using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server.Shared.Services;

public class OrganizationService_debug : IOrganizationService
{
    private static List<Organization> Organizations { get; } = new List<Organization> 
    {
        new Organization { Id = "debug_organizationId", Name = "debug_organizationName" },
        new Organization { Id = "debug_organizationId_2", Name = "debug_organizationName2" },
    };
    public Organization CurrentOrganization { get; set; } = Organizations.First();

    public Task CreateNew(string userId, Organization organization)
    {
        return Task.Run(() => Organizations.Add(organization));
    }
    public async Task<ICollection<Organization>> GetAll(string userId)
    {
        return await Task.FromResult(Organizations);
    }
    public async Task<Organization?> GetCurrent(string userId)
    {
        return await Task.FromResult(CurrentOrganization);
    }
    public async Task SetAsActive(string userId, Organization organization)
    {
        await Task.Run(() => CurrentOrganization = organization);
    }
}
