using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Application
{
    [Key]
    [StringLength(50)]
    public required string Name { get; set; }
    public ICollection<Role> Roles { get; set; } = Array.Empty<Role>();
    public ICollection<AppLicense> Licenses { get; set; } = Array.Empty<AppLicense>();
}
