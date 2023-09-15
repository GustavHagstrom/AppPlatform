﻿using SharedLibrary.Enums.BidconAccess;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class SheetSection : IViewSection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumnDefinition> Columns { get; set; } = new();
}
