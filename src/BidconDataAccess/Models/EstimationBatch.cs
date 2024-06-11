﻿namespace AppPlatform.BidconDatabaseAccess.Models;
public record EstimationBatch(
    Estimation Estimation,
    ICollection<EstimationSheet> SheetResults,
    ICollection<MixedElementLayer> MELayers,
    ICollection<DesignElementLayer> DELayers,
    ICollection<WorkResultLayer> WRLayers,
    ICollection<Resource> Resources,
    ICollection<ResourceFactor> ResourceFactors,
    ICollection<ATA> ATAs,
    ICollection<ATAFactor> ATAFactors);
