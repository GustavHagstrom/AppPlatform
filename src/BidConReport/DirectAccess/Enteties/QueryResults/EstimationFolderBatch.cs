﻿namespace BidConReport.DirectAccess.Enteties.QueryResults;
public record EstimationFolderBatch(IEnumerable<EstimationResult> Estimations, IEnumerable<EstimationFolderResult> folders);