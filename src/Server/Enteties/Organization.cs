using Server.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class Organization
{
    [StringLength(50)]
    public required string Id { get; set; }
    public IEnumerable<User>? Users { get; set; }
    public BidconAccessCredentials? BidconCredentials { get; set; }
    public License? License { get; set; }
    public IEnumerable<EstimationViewTemplate>? EstimationViewTemplates { get; set; }
}
