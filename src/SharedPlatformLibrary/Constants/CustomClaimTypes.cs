namespace SharedPlatformLibrary.Constants;
public static class CustomClaimTypes
{
    public const string OrganizationMemberOf = "OrganizationMemberOf";
    public const string CurrentOrganizationId = "Organization";
    public const string License = "License";

    public static ICollection<string> GetAllTypesAsCollection()
    {
        return new[]
        {
            OrganizationMemberOf,
            CurrentOrganizationId,
            License,
        };
    }
}
