namespace SharedPlatformLibrary.Enteties;
public class AppSeedModel
{
    public required string ApplicationName { get; set; }
    public required ICollection<string> Roles { get; set; }
}
