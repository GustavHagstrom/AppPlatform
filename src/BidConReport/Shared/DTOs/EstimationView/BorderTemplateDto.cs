using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Shared.DTOs.EstimationView;

public class BorderTemplateDto
{
    public Guid Id { get; set; }
    public bool BorderLeft { get; set; }
    public bool BorderTop { get; set; }
    public bool BorderRight { get; set; }
    public bool BorderBottom { get; set; }
    public BorderStyle Style { get; set; }

}
