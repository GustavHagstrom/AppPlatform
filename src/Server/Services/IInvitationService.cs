using Server.Data;
using Server.Enteties;
using System.Security.Claims;

namespace Server.Services;
public interface IInvitationService
{
    Task AcceptInvitaionAsync(ClaimsPrincipal userClaims, OrganizationInvitaion invitaion);
    Task SendAsync(ClaimsPrincipal userClaims, string email);
    Task<OrganizationInvitaion?> GetAsync(string Id);
    Task<IEnumerable<OrganizationInvitaion>> GetAllAsync(Organization organization);
    Task UpdateAsync(OrganizationInvitaion invitation);
}