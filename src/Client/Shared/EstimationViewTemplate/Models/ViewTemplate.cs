﻿using Client.Shared.EstimationViewTemplate.Models.SectionModels;
using SharedLibrary.DTOs.EstimationView;

namespace Client.Shared.EstimationViewTemplate.Models;
public class ViewTemplate
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public List<DataSection> DataSections { get; set; } = new();
    public List<SheetSection> SheetSections { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
