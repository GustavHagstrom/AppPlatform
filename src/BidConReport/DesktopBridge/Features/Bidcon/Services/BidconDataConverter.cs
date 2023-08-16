using BidCon.SDK.Database;
using BidConReport.Shared.DTOs;
using BidConReport.DesktopBridge.Features.Bidcon.Factories;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public class BidconDataConverter : IBidconDataConverter
{
    private readonly IEstimationFactory _estimationFactory;

    public BidconDataConverter(IEstimationFactory estimationFactory)
    {
        _estimationFactory = estimationFactory;
    }
    public DbFolderDTO ConvertDatabaseFolder(DatabaseFolder folder)
    {
        var returnFolder = new DbFolderDTO { Name = folder.Name, SubFolders = new List<DbFolderDTO>(), DbEstimations = new List<DbEstimationDTO>() };
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
    private static DbEstimationDTO CreateDbEstimation(DatabaseEstimation databaseEstimation)
    {
        return new DbEstimationDTO
        {
            Id = databaseEstimation.ID,
            Name = databaseEstimation.Name,
            Description = databaseEstimation.Description,
        };
    }
    public Shared.DTOs.EstimationDTO ConvertEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettingsDto settings)
    {
        return _estimationFactory.Create(estimation, settings);
    }


}
