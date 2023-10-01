using Client.Shared.EstimationViewTemplate.Models.SectionModels;

namespace Client.Features.Settings.EstimationView.Models;

public record SectionSelection(IViewSection Section, ISectionTool? ActiveTool);