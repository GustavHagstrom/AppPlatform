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
    public static class ImportController
    {
        /// <summary>
        /// Get request. Returns all ImportSettings associated with current Organization
        /// </summary>
        public const string All = "api/ImportSettings/All";
        /// <summary>
        /// Get request. Returns the default ImportSetting for current user if there is one
        /// </summary>
        public const string Default = "api/ImportSettings/Default";
        /// <summary>
        /// Post request. Upsert importsettings from json body
        /// </summary>
        public const string Upsert = "api/ImportSettings/Upsert";
        /// <summary>
        /// Delete request. Deletes importsettings. Parameter appended as /{id} in the request Uri
        /// </summary>
        public const string Delete = "api/ImportSettings/Delete";
        /// <summary>
        /// Post request. Set importSettings as default. id as json body. Id may be null resulting in no default settings.
        /// </summary>
        public const string SetDefault = "api/ImportSettings/SetDefault";
    }
    public static class ReportTemplatesController
    {
        /// <summary>
        /// Get request. Returns all ReportTemplates associated with current Organization
        /// </summary>
        public const string All = "api/ReportTemplates";
        /// <summary>
        /// Get request. Returns the default ReportTemplate for current user if there is one
        /// </summary>
        public const string Default = "api/ReportTemplates/Default";
        /// <summary>
        /// Post request. Upsert ReportTemplates from json body
        /// </summary>
        public const string Upsert = "api/ReportTemplates/Upsert";
        /// <summary>
        /// Delete request. Deletes ReportTemplates. Parameter appended as /{id} in the request Uri
        /// </summary>
        public const string Delete = "api/ReportTemplates/Delete";
        /// <summary>
        /// Post request. Set ReportTemplate as default. id as json body. Id may be null resulting in no default settings.
        /// </summary>
        public const string SetDefault = "api/ReportTemplates/SetAsDefault";
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
    public static class OrganizationsController
    {
        /// <summary>
        /// Get request. Returns all organizations for the user
        /// </summary>
        public const string GetAll = "api/Organizations";
        /// <summary>
        /// Get request. Returns currently active organization
        /// </summary>
        public const string GetCurrent = "api/Organizations/Current";
        /// <summary>
        /// Post request. Sets currently active organization. Organization as body
        /// </summary>
        public const string SetAsCurrent = "api/Organizations/SetAsCurrent";
        /// <summary>
        /// Post request. Creates new and sets it as currently acive organization. Organization as body
        /// </summary>
        public const string Create = "api/Organizations/Create";
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
}

