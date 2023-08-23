namespace BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
public record EstimationBatch(
    EstimationResult Estimation,
    ICollection<EstimationSheetResult> Sheet,
    ICollection<MixedElementLayerResult> MELayer,
    ICollection<DesignElementLayerResult> DELayer,
    ICollection<WorkResultLayerResult> WRLayer,
    ICollection<ResourceResult> Resource,
    ICollection<ResourceFactorResult> ResourceFactors,
    ICollection<ATAResult> ATAResults,
    ICollection<ATAFactorResult> ATAFactorResults);
