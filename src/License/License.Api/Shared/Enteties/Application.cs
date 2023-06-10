using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Application
{
    //public int Id { get; set; }
    [Key]
    [StringLength(50)]
    public required string Name { get; set; }
    // Other application properties

    public ICollection<Role> Roles { get; set; }
    public ICollection<AppLicense> Licenses { get; set; }
}
