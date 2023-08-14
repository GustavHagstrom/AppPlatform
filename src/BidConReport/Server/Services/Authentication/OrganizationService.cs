using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Services.Authentication;

public class OrganizationService : IOrganizationService
{
    public Task CreateNew(string userId, OrganizationDTO organization)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<OrganizationDTO>> GetAll(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<OrganizationDTO?> GetCurrent(string userId)
    {
        throw new NotImplementedException();
    }

    public Task SetAsActive(string userId, OrganizationDTO organization)
    {
        throw new NotImplementedException();
    }
}
