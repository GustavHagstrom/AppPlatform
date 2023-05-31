using BidCon.SDK;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationFactory
{
    Shared.Entities.Estimation Create(BidCon.SDK.Estimation estimation, EstimationImportSettings settings);
}