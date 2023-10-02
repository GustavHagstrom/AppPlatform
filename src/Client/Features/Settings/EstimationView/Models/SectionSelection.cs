using Client.Shared.EstimationViewTemplate.Models.SectionModels;

namespace Client.Features.Settings.EstimationView.Models;

public class SectionSelection
{
    public SectionSelection(IViewSection section, ISectionTool? activeTool)
    {
        Section = section;
        ActiveTool = activeTool;
    }

    public IViewSection Section { get; set; }
    public ISectionTool? ActiveTool { get; set; }
}