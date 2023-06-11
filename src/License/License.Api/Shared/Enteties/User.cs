using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class User
{
    [StringLength(50)]
    public string Id { get; set; }
    public ICollection<Role> Roles { get; set; }
    public ICollection<Organization> Organizations { get; set; }
    //[StringLength(50)]
    //public string OrganizationName { get; set; }
    public AppLicense License { get; set; }
    public int LicenseId { get; set; }
}
