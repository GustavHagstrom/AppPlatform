using BidConReport.Shared.Enums.BidconAccess;

namespace BidConReport.Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class SheetSection : IReportSection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumnDefinition> Columns { get; set; } = new();
}
