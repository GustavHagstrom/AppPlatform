using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SharedPlatformLibrary.Enteties;
public class Organization
{
    public required string Id { get; set; }
    [StringLength(50)]
    [Required]
    public required string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
