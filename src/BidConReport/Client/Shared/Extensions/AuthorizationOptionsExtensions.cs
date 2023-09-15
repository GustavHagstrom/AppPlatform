using Microsoft.AspNetCore.Authorization;

namespace BidConReport.Client.Shared.Extensions;

public static class AuthorizationOptionsExtensions
{
    /// <summary>
    /// Adds all required policies for the application
    /// Policy names should be listed as constans in a static class
    /// </summary>
    /// <param name="options"></param>
    public static void AddCustomPolicies(this AuthorizationOptions options)
    {

    }
}
