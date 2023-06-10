using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Organization
{
    [Key]
    public required string Name { get; set; }
    // Other organization properties

    public ICollection<User> Users { get; set; }
    public ICollection<AppLicense> Licenses { get; set; }
}
