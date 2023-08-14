using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Shared.Services;
public interface IOrganizationService
{
    Task<ICollection<OrganizationDTO>> GetAll(string userId);
    Task<OrganizationDTO?> GetCurrent(string userId);
    Task SetAsActive(string userId, OrganizationDTO organization);
    Task CreateNew(string userId, OrganizationDTO organization);
}