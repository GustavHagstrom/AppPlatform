namespace SharedPlatformLibrary.Constants;
public static class CustomClaimTypes
{
    public const string License = "License";
    public const string ApplicationRight = "AppRight";

    public static ICollection<string> GetAllTypesAsCollection()
    {
        return new[]
        {
            License,
            ApplicationRight,
        };
    }
}
