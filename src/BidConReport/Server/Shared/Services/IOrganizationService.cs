using SharedPlatformLibrary.Enteties;

namespace BidConReport.Server.Shared.Services;
public interface IOrganizationService
{
    Task<ICollection<Organization>> GetAll(string userId);
    Task<Organization?> GetCurrent(string userId);
    Task SetAsActive(string userId, Organization organization);
    Task CreateNew(string userId, Organization organization);
}