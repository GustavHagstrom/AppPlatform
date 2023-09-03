namespace BidConReport.Shared.DTOs.BidconAccess;
public record EstimationBatchDto(
    EstimationDto Estimation,
    ICollection<EstimationSheetDto> SheetResults,
    ICollection<MixedElementLayerDto> MELayers,
    ICollection<DesignElementLayerDto> DELayers,
    ICollection<WorkResultLayerDto> WRLayers,
    ICollection<ResourceDto> Resources,
    ICollection<ResourceFactorDto> ResourceFactors,
    ICollection<ATADto> ATADtos,
    ICollection<ATAFactorDto> ATAFactors);
