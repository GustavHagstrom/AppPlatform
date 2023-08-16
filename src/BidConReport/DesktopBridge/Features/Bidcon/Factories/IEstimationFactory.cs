using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationFactory
{
    Shared.DTOs.EstimationDTO Create(BidCon.SDK.Estimation estimation, EstimationImportSettingsDto settings);
}