using System.ComponentModel.DataAnnotations;

namespace License.Api.Shared.Enteties;
public class Role
{
    public int Id { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public ICollection<User> Users { get; set; } = Array.Empty<User>();
    [StringLength(50)]
    public Application? Application { get; set; }
    public required string ApplicationName { get; set; }
    
}
