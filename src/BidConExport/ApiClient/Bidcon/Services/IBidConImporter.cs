using BidCon.SDK.Database;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.Services;
public interface IBidConImporter
{
    DatabaseUser DatabaseUser { get; }

    IEnumerable<DbEstimation> GetAllEstimations();
    SimpleEstimation GetEstimation(string id, EstimationImportSettings settings);
    DbFolder GetFolderStructure();
}