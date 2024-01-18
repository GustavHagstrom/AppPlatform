using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Shared.DTOs.EstimationView;
public class HeaderOrFooter
{
    public Guid Id { get; set; }
    public required string Value { get; set; }
    public required HeaderOrFooterPosition Position { get; set; }

}
