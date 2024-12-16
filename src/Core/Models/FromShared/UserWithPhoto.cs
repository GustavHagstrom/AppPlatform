using Microsoft.Graph.Models;

namespace AppPlatform.Core.Models.FromShared;
public class UserWithPhoto
{
    public required User User { get; set; }
    public string? PhotoBase64 { get; set; }
}
