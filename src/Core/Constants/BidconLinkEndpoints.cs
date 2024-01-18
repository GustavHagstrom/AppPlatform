namespace AppPlatform.Core.Constants;
public static class BidconLinkEndpoints
{
    /// <summary>
    /// Post request. EstimationRequestBatchModelDto as body. Returns a single estimationbatch
    /// </summary>
    public const string GetEstimationBatch = "api/BidconAccess/GetEstimationBatch";
    /// <summary>
    /// Post request. EstimationRequestBatchesModelDto as body. Returns multiple estimationbatches
    /// </summary>
    public const string GetEstimationBatches = "api/BidconAccess/GetEstimationBatches";
    /// <summary>
    /// Get request. Returns all estimations
    /// </summary>
    public const string GetEstimationList = "api/BidconAccess/GetEstimationList";
    /// <summary>
    /// Get request. Returns a FolderBatch
    /// </summary>
    public const string GetFolderBatch = "api/BidconAccess/GetFolderBatch";
}
