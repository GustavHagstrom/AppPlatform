namespace BidConReport.Shared.Features.ReportLayout.Header;
public class HeaderDefinition
{
    public int Id { get; set; }
    public FontProperties Font { get; set; } = FontProperties.Default;
    /// <summary>
    /// string value with EstimationInfoDataTags to be translated into a single string at presentation
    /// </summary>
    public string InterpolationValue { get; set; } = string.Empty;
}


