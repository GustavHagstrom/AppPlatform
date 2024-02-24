using Microsoft.Graph.Models;

namespace AppPlatform.Shared.Services.MicrosoftGraph;
public class UserWithPhoto
{
    public required User User { get; set; }
    public string? PhotoBase64 { get; set; }
}
