namespace SharedLibrary.DTOs.BidconAccess;
public record BC_EstimationBatchDto(
    BC_EstimationDto Estimation,
    ICollection<BC_EstimationSheetDto> SheetResults,
    ICollection<BC_MixedElementLayerDto> MELayers,
    ICollection<BC_DesignElementLayerDto> DELayers,
    ICollection<BC_WorkResultLayerDto> WRLayers,
    ICollection<BC_ResourceDto> Resources,
    ICollection<BC_ResourceFactorDto> ResourceFactors,
    ICollection<BC_ATADto> ATAs,
    ICollection<BC_ATAFactorDto> ATAFactors);
