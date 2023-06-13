using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class User
{
    [StringLength(50)]
    public required string Id { get; set; }
    public ICollection<Role> Roles { get; set; } = Array.Empty<Role>();
    public ICollection<Organization> Organizations { get; set; } = Array.Empty<Organization>();
    public ICollection<AppLicense> Licenses { get; set; } = Array.Empty<AppLicense>();
    public Organization? CurrentOrganization { get; set; }
    public string? CurrentOrganizationName { get; set; }
}
