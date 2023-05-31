using BidCon.SDK;
using BidCon.SDK.Database;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidconDataConverter
{
    //IEnumerable<DbEstimation> SimplifieAllEstimations(DatabaseFolder folder);
    DbFolder ConvertDatabaseFolder(DatabaseFolder folder);
    Shared.Entities.Estimation ConvertEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettings settings);
}