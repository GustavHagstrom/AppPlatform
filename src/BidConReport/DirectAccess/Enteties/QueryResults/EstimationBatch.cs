namespace BidConReport.DirectAccess.Enteties.QueryResults;
public record EstimationBatch(
    EstimationResult Estimation,
    ICollection<EstimationSheetResult> Sheet,
    ICollection<MixedElementLayerResult> MELayer,
    ICollection<DesignElementLayerResult> DELayer,
    ICollection<WorkResultLayerResult> WRLayer,
    ICollection<ResourceResult> Resource);
