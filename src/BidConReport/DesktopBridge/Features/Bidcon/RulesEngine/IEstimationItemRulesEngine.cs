﻿using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
public interface IEstimationItemRulesEngine
{
    bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings);
}