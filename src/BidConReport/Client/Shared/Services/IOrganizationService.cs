using SharedPlatformLibrary.DTOs;

namespace BidConReport.Client.Shared.Services;
public interface IOrganizationService
{
    Task<ICollection<OrganizationDTO>> GetAll();
    Task<OrganizationDTO?> GetCurrent();
    Task SetAsActive(OrganizationDTO organization);
    Task CreateNew(OrganizationDTO organization);
}