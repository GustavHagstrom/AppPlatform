using Microsoft.Graph.Models;

namespace AppPlatform.Data.MongoDb.Enteties.FromShared;
public class UserWithPhoto
{
    public required User User { get; set; }
    public string? PhotoBase64 { get; set; }
}
