﻿namespace BidConReport.Shared.Constants;
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
        public const string Upsert = "api/ImportSettings/Upsert";
        /// <summary>
        /// Delete request. Deletes ReportTemplates. Parameter appended as /{id} in the request Uri
        /// </summary>
        public const string Delete = "api/ImportSettings/Delete";
        /// <summary>
        /// Post request. Set ReportTemplate as default. id as json body. Id may be null resulting in no default settings.
        /// </summary>
        public const string SetDefault = "api/ImportSettings/SetDefault";
    }
}

