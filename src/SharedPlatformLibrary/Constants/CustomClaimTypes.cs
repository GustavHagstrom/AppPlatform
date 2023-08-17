namespace SharedPlatformLibrary.Constants;
public static class CustomClaimTypes
{
    public const string CurrentOrganization = "Organization";
    public const string License = "License";

    public static ICollection<string> GetAllTypesAsCollection()
    {
        return new[]
        {
            CurrentOrganization,
            License,
        };
    }
}
