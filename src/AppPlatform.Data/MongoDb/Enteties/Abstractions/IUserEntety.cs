using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Data.MongoDb.Enteties.Abstractions;
public interface IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; }
}
