﻿namespace BidConReport.BidconAccess.Enteties.QueryResults;
public record EstimationFolderBatch(IEnumerable<EstimationResult> Estimations, IEnumerable<EstimationFolderResult> Folders);