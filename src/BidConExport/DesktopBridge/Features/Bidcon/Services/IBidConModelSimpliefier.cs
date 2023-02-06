using BidCon.SDK;
using BidCon.SDK.Database;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidConModelSimpliefier
{
    IEnumerable<DbEstimation> SimplifieAllEstimations(DatabaseFolder folder);
    DbFolder SimplifieBidConFolderStructure(DatabaseFolder folder);
    SimpleEstimation SimplifieEstimation(Estimation estimation, EstimationImportSettings settings);
}