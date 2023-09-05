﻿using BidConReport.Shared.DTOs.BidconAccess;
using BidConReport.Client.Shared.EstimationProcessing.Models;

namespace BidConReport.Client.Shared.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatchDto batch);
}