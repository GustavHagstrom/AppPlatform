using BidCon.SDK.Database;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.Services;
public interface IBidConImporter
{
    IEnumerable<DbEstimation> GetAllEstimations();
    SimpleEstimation GetEstimation(string id, EstimationImportSettings settings);
    DbFolder GetFolderStructure();
}