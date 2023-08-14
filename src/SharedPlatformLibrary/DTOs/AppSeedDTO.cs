namespace SharedPlatformLibrary.DTOs;
public class AppSeedDTO
{
    public required string ApplicationName { get; set; }
    public required ICollection<string> Roles { get; set; }
}
