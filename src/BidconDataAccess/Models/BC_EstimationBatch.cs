﻿namespace AppPlatform.BidconDataAccess.Models;
public record BC_EstimationBatch(
    BC_Estimation Estimation,
    ICollection<BC_EstimationSheet> SheetResults,
    ICollection<BC_MixedElementLayer> MELayers,
    ICollection<BC_DesignElementLayer> DELayers,
    ICollection<BC_WorkResultLayer> WRLayers,
    ICollection<BC_Resource> Resources,
    ICollection<BC_ResourceFactor> ResourceFactors,
    ICollection<BC_ATA> ATAs,
    ICollection<BC_ATAFactor> ATAFactors);
