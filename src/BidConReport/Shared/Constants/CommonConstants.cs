namespace BidConReport.Shared.Constants;
public static class CommonConstants
{
    /// <summary>
    /// This is used as a primary key in the LicenseDb and 
    /// probably cannot be changed once in production
    /// </summary>
    public const string ApplicationName = "BidconReport";
    /// <summary>
    /// This is used in the licenseDb and probably a bad idea to change once in production
    /// </summary>
    public static readonly string[] AppRoles = { "admin", "creator", "reader", "guest" };
}
