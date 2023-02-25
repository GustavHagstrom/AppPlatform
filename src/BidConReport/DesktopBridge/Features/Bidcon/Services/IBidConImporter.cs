using BidCon.SDK.Database;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidConImporter
{
    IEnumerable<DbEstimation> GetAllEstimations();
    Estimation GetEstimation(string id, EstimationImportSettings settings);
    DbFolder GetFolderStructure();
}