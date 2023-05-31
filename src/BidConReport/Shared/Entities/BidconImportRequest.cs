namespace BidConReport.Shared.Entities;
public class BidconImportRequest
{
    public required DbEstimation Estimation { get; set; }
    public required EstimationImportSettings Settings { get; set; }
}
