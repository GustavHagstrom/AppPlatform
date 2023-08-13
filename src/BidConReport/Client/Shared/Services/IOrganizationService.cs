using SharedPlatformLibrary.Enteties;

namespace BidConReport.Client.Shared.Services;
public interface IOrganizationService
{
    Task<ICollection<Organization>> GetAll();
    Task<Organization?> GetCurrent();
    Task SetAsActive(Organization organization);
    Task CreateNew(Organization organization);
}