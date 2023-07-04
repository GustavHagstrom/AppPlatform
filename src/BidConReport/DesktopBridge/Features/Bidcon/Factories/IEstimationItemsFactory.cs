using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationItemsFactory
{
    ICollection<EstimationItem> Create(BidCon.SDK.EstimationItem root, EstimationImportSettings settings, ref int row, double costFactor);
}