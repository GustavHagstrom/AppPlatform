using BidConReport.Shared.DTOs;

namespace BidConReport.Shared.DTOs;
public class BidconImportRequestDTO
{
    public required DbEstimationDTO Estimation { get; set; }
    public required EstimationImportSettingsDTO Settings { get; set; }
}
