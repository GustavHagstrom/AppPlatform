using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Features.ReportLayout.Models.GeneralInformation;
using BidConReport.Shared.Features.ReportLayout.Models.Header;
using BidConReport.Shared.Features.ReportLayout.Models.Price;
using BidConReport.Shared.Features.ReportLayout.Models.Table;
using BidConReport.Shared.Features.ReportLayout.Models.Title;

namespace BidConReport.Shared.Features.ReportLayout.Models;
public class LayoutDefinition
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string OrganizationId { get; set; } = string.Empty;
    public HeaderDefinition TopLeftHeader { get; set; } = new();
    public HeaderDefinition TopRightHeader { get; set; } = new();
    public TitleSection TitleSection { get; set; } = new TitleSection { LayoutOrder = 1 };
    public GeneralInformationSection GeneralInformationSection { get; set; } = GeneralInformationSection.Default;
    public PriceSection PriceSection { get; set; } = new PriceSection { LayoutOrder = 3 };
    public TableSection TableSection { get; set; } = TableSection.Default;
    //public List<ILayoutSection> Sections { get; set; } = new();

    //public static LayoutDefinition Default => CreateDefaultLayoutDefinition();
    //private static LayoutDefinition CreateDefaultLayoutDefinition()
    //{
    //    var generalInfo = GeneralInformationSection.Default;
    //    generalInfo.LayoutOrder = 2;

    //    return new LayoutDefinition
    //    {
    //        Sections = new List<ILayoutSection>()
    //        {
    //            new TitleSection { LayoutOrder = 1},
    //            generalInfo,
    //            new PriceSection { LayoutOrder = 3},
    //        },
    //    };
    //}
}
