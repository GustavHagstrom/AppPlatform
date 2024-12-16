using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Models.Abstractions;
public interface ITenantEntety
{
    [StringLength(50)]
    public string TenantId { get; set; }
}
