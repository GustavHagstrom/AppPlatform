namespace SharedPlatformLibrary.Constants;
public static class CustomClaimTypes
{
    public const string CurrentOrganizatio = "Organization";
    public const string License = "License";

    public static ICollection<string> GetAllTypesAsCollection()
    {
        return new[]
        {
            CurrentOrganizatio,
            License,
        };
    }
}
