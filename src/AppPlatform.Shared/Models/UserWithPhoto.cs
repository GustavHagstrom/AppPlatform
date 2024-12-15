using Microsoft.Graph.Models;

namespace AppPlatform.Shared.Models;
public class UserWithPhoto
{
    public required User User { get; set; }
    public string? PhotoBase64 { get; set; }
}
