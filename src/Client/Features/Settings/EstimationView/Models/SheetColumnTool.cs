using Client.Shared.EstimationViewTemplate.Models.SectionModels;

namespace Client.Features.Settings.EstimationView.Models;

public class SheetColumnTool : ISectionTool
{
    public required SheetColumn Column { get; set; }
}
