using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Organization
{
    [Key]
    [StringLength(50)]
    public required string Name { get; set; }
    public ICollection<User> Users { get; set; } = Array.Empty<User>();
    public ICollection<AppLicense> Licenses { get; set; } = Array.Empty<AppLicense>();
}
