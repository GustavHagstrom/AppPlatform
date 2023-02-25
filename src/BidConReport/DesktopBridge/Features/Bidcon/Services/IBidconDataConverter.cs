using BidCon.SDK;
using BidCon.SDK.Database;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidconDataConverter
{
    //IEnumerable<DbEstimation> SimplifieAllEstimations(DatabaseFolder folder);
    DbFolder ConvertDatabaseFolder(DatabaseFolder folder);
    Shared.Models.Estimation ConvertEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettings settings);
}