namespace AppPlatform.BidconDatabaseAccess.Models;
public record D_EstimationBatch(
    D_Estimation Estimation,
    ICollection<D_EstimationSheet> SheetResults,
    ICollection<D_MixedElementLayer> MELayers,
    ICollection<D_DesignElementLayer> DELayers,
    ICollection<D_WorkResultLayer> WRLayers,
    ICollection<D_Resource> Resources,
    ICollection<D_ResourceFactor> ResourceFactors,
    ICollection<D_ATA> ATAs,
    ICollection<D_ATAFactor> ATAFactors);
