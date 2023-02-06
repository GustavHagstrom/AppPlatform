using BidCon.SDK;
using BidCon.SDK.Database;
using BidConReport.Shared.Models;
using BidConReport.DesktopBridge.Features.Bidcon.Factories;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public class BidConModelSimpliefier : IBidConModelSimpliefier
{
    private readonly ISimpleEstimationFactory _simpleEstimationFactory;

    public BidConModelSimpliefier(ISimpleEstimationFactory simpleEstimationFactory)
    {
        _simpleEstimationFactory = simpleEstimationFactory;
    }
    public DbFolder SimplifieBidConFolderStructure(DatabaseFolder folder)
    {
        var returnFolder = new DbFolder { Name = folder.Name };
        foreach (var subFolder in folder.Folders)
        {
            returnFolder.SubFolders.Add(SimplifieBidConFolderStructure(subFolder));
        }
        foreach (var estimation in folder.Estimations)
        {
            returnFolder.DbEstimations.Add(CreateDbEstimation(estimation));
        }
        return returnFolder;
    }
    public IEnumerable<DbEstimation> SimplifieAllEstimations(DatabaseFolder folder)
    {
        foreach (var subFolder in folder.Folders)
        {
            foreach (var estimation in SimplifieAllEstimations(subFolder))
            {
                yield return estimation;
            }
        }
        foreach (var estimation in folder.Estimations)
        {
            yield return CreateDbEstimation(estimation);
        }
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

    public SimpleEstimation SimplifieEstimation(Estimation estimation, EstimationImportSettings settings)
    {
        return _simpleEstimationFactory.CreateSimpleEstimation(estimation, settings);
    }


}
