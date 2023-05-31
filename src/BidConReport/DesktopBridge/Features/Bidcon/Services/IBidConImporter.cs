using BidCon.SDK.Database;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public interface IBidConImporter
{
    //IEnumerable<DbEstimation> GetAllEstimations();
    BidCon.SDK.Estimation GetEstimation(string id);
    DatabaseFolder GetDatabaseFolder();
}