using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Data.MongoDb.Enteties.Abstractions;
public interface ITenantEntety
{
    [StringLength(50)]
    public string TenantId { get; set; }
}
