using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server.Shared.Services;

public class OrganizationService : IOrganizationService
{
    public Task CreateNew(string userId, Organization organization)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Organization>> GetAll(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Organization?> GetCurrent(string userId)
    {
        throw new NotImplementedException();
    }

    public Task SetAsActive(string userId, Organization organization)
    {
        throw new NotImplementedException();
    }
}
