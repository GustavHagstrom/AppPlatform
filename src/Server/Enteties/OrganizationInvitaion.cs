using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Server.Enteties;

public class OrganizationInvitaion
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(450)]
    public string Email { get; set; } = string.Empty;
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
    public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
    
    public enum InvitationStatus
    {
        Pending,
        Accepted,
        Rejected,
        Expired
    }
}
