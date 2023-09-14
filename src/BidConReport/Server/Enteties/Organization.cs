using BidConReport.Server.Enteties.EstimationView;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class Organization
{
    [StringLength(50)]
    public required string Id { get; set; }
    public IEnumerable<User>? Users { get; set; }
    public BidconCredentials? BidconCredentials { get; set; }
    public License? License { get; set; }
    public IEnumerable<EstimationViewTemplate>? EstimationViewTemplates { get; set; }
    public IEnumerable<Role>? Roles { get; set; }
}
