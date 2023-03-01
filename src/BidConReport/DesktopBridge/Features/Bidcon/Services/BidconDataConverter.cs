using BidCon.SDK.Database;
using BidConReport.Shared.Models;
using BidConReport.DesktopBridge.Features.Bidcon.Factories;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public class BidconDataConverter : IBidconDataConverter
{
    private readonly IEstimationFactory _estimationFactory;

    public BidconDataConverter(IEstimationFactory estimationFactory)
    {
        _estimationFactory = estimationFactory;
    }
    public DbFolder ConvertDatabaseFolder(DatabaseFolder folder)
    {
        var returnFolder = new DbFolder { Name = folder.Name, SubFolders = new List<DbFolder>(), DbEstimations = new List<DbEstimation>() };
        foreach (var subFolder in folder.Folders)
        {
            returnFolder.SubFolders.Add(ConvertDatabaseFolder(subFolder));
        }
        foreach (var estimation in folder.Estimations)
        {
            returnFolder.DbEstimations.Add(CreateDbEstimation(estimation));
        }
        return returnFolder;
    }
    private static DbEstimation CreateDbEstimation(DatabaseEstimation databaseEstimation)
    {
        return new DbEstimation
        {
            Id = databaseEstimation.ID,
            Name = databaseEstimation.Name,
            Description = databaseEstimation.Description,
        };
    }
    public Shared.Models.Estimation ConvertEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettings settings)
    {
        return _estimationFactory.Create(estimation, settings);
    }


}
