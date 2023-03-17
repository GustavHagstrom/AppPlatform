using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Features.ReportLayout.Models.Header;

namespace BidConReport.Shared.Features.ReportLayout.Models;
public class LayoutDefinition
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string OrganizationId { get; set; }
    public HeaderDefinition TopLeftHeader { get; set; } = new();
    public HeaderDefinition TopRightHeader { get; set; } = new();
    public List<ILayoutSection> Sections { get; set; } = new();


}
