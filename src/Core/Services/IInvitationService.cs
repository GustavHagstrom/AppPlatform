using AppPlatform.Core.Data;
using AppPlatform.Core.Enteties;
using System.Security.Claims;

namespace AppPlatform.Core.Services;
public interface IInvitationService
{
    Task AcceptInvitaionAsync(ClaimsPrincipal userClaims, OrganizationInvitaion invitaion);
    Task SendAsync(ClaimsPrincipal userClaims, string email);
    Task<OrganizationInvitaion?> GetAsync(string Id);
    Task<IEnumerable<OrganizationInvitaion>> GetAllAsync(Organization organization);
    Task UpdateAsync(OrganizationInvitaion invitation);
}