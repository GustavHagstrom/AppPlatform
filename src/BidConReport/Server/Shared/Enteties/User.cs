using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Shared.Enteties;

public class User
{
    [StringLength(50)]
    public required string Id { get; set; }
    public bool IsDarkMode { get; set; } = false;
    //[StringLength(50)]
    //public int? CurrentUserOrganizationId { get; set; }
    //public UserOrganization? CurrentUserOrganization { get; set; }
    public ICollection<UserOrganization>? UserOrganizations { get; set; }
}
