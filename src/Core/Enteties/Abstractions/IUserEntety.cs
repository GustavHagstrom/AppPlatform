using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.Abstractions;
public interface IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; }
}
