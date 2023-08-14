using BidCon.SDK;
using BidCon.SDK.Database;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidconDataConverter
{
    //IEnumerable<DbEstimation> SimplifieAllEstimations(DatabaseFolder folder);
    DbFolderDTO ConvertDatabaseFolder(DatabaseFolder folder);
    Shared.DTOs.EstimationDTO ConvertEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettingsDTO settings);
}