namespace BidConReport.Shared.Constants;
public static class BackendApiEndpoints
{
    public static class ClaimEnpoints
    {
        /// <summary>
        /// Get request to get current user app-specific claims
        /// </summary>
        public const string Get = "api/claims";
    }
    public static class DarkModeController
    {
        /// <summary>
        /// Get request. Returns a bool indicating user darkmode preference
        /// </summary>
        public const string Get = "api/DarkMode";
        /// <summary>
        /// Put request. bool as request body
        /// </summary>
        public const string Put = "api/DarkMode";
    }
    public static class BidconCredentialsController
    {
        /// <summary>
        /// Get request. Returns credential for the organization. Null if none has benn configured
        /// </summary>
        public const string Get = "api/BidconCredentials";
        /// <summary>
        /// Post request. BC_DatabaseCredentialsDto as json body. Upserts the credentials
        /// </summary>
        public const string Upsert = "api/BidconCredentials";
    }
    public static class EstimationViewTemplateController
    {
        /// <summary>
        /// Get request. Guid as query parameter. May return NoContent.
        /// </summary>
        public const string Get = "api/EstimationViewTemplate";
        /// <summary>
        /// Post request. Dto as body parameter.
        /// </summary>
        public const string Upsert = "api/EstimationViewTemplate";
        /// <summary>
        /// Delete request. Guid as query parameter.
        /// </summary>
        public const string Delete = "api/EstimationViewTemplate";
        /// <summary>
        /// Get request. Gets list of templates without nested properties. May returns NoContent.
        /// </summary>
        public const string GetShallowList = "api/EstimationViewTemplate/Shallow";
        /// <summary>
        /// Get request. Gets list of templates with nested properties. May returns NoContent.
        /// </summary>
        public const string GetDeepList = "api/EstimationViewTemplate/Deep";
    }
}

