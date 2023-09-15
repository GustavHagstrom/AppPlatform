namespace BidConReport.Shared.Constants;
public static class ApplicationClaimConstants
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
