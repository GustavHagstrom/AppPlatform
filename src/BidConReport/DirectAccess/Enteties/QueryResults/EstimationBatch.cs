namespace BidConReport.DirectAccess.Enteties.QueryResults;
public record EstimationBatch(
    EstimationResult Estimation,
    ICollection<EstimationSheetResult> Sheet,
    ICollection<MixedElementLayerResult> MELayer,
    ICollection<DesignElementResult> DE,
    ICollection<DesignElementLayerResult> DELayer,
    ICollection<WorkResultResult> WR,
    ICollection<WorkResultLayerResult> WRLayer,
    ICollection<ResourceResult> Resource);
