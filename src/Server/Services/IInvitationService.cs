using Server.Enteties;
using System.Security.Claims;

namespace Server.Services;
public interface IInvitationService
{
    Task AcceptInvitaionAsync(ClaimsPrincipal userClaims, OrganizationInvitaion invitaion);
    Task Create(ClaimsPrincipal userClaims, string email);
    Task<OrganizationInvitaion?> GetAsync(string Id);
    Task UpdateAsync(OrganizationInvitaion invitation);
}