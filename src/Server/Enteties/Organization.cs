using Server.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class Organization
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    public IEnumerable<UserOrganization>? UserOrganizations { get; set; }
    public IEnumerable<OrganizationInvitaion>? OrganizationInvitaions { get; set; }
    public BidconAccessCredentials? BidconCredentials { get; set; }
    public License? License { get; set; }
    public IEnumerable<EstimationViewTemplate>? EstimationViewTemplates { get; set; }
}
