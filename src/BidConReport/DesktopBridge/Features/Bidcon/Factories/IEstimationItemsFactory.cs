using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationItemsFactory
{
    ICollection<EstimationItemDTO> Create(BidCon.SDK.EstimationItem root, EstimationImportSettingsDTO settings, ref int row, double costFactor);
}