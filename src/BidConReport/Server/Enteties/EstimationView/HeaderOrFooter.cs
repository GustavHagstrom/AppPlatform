﻿using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Server.Enteties.EstimationView;
public class HeaderOrFooter : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public required string Value { get; set; }
    public required HeaderOrFooterPosition Position { get; set; }



    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationViewTemplate { get; set; }
}
