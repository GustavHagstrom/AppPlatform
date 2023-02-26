using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationFactory
{
    Shared.Models.Estimation Create(BidCon.SDK.Estimation estimation, EstimationImportSettings settings);
}