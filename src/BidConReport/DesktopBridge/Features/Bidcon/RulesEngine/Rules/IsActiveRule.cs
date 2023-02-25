﻿using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class IsActiveRule : IEstimationItemRule
{
    public bool Run(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return estimationItem.IsActive;
    }
}
