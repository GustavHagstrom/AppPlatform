using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Models.Abstractions;
public interface IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; }
}
