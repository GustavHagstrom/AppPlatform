using BidCon.SDK.Database;
using BidConReport.SharedLibrary.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidConImporter
{
    IEnumerable<DbEstimation> GetAllEstimations();
    SimpleEstimation GetEstimation(string id, EstimationImportSettings settings);
    DbFolder GetFolderStructure();
}