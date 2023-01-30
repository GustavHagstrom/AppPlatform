using BidCon.SDK.Database;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.Services;
public class BidConImporter : IBidConImporter
{
    private readonly IBidConConfigProvider _bidConConfigProvider;
    private readonly IBidConModelSimpliefier _bidConModelSimpliefier;
    private DatabaseUser? _databaseUser;
    public BidConImporter(IBidConConfigProvider bidConConfigProvider, IBidConModelSimpliefier bidConModelSimpliefier)
    {
        _bidConConfigProvider = bidConConfigProvider;
        _bidConModelSimpliefier = bidConModelSimpliefier;
    }
    public DatabaseUser DatabaseUser
    {
        get
        {
            if (_databaseUser is null)
            {
                LoginUser();
            }
            return _databaseUser!;
        }
    }

    private void LoginUser()
    {
        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromConfig(_bidConConfigProvider.GetBidConConfigFilePath());
        _databaseUser = app.Login(_bidConConfigProvider.GetUserName(), _bidConConfigProvider.GetPassword());
    }
    public DbFolder GetFolderStructure()
    {
        return _bidConModelSimpliefier.SimplifieBidConFolderStructure(DatabaseUser.ReadEstimations());
    }
    public IEnumerable<DbEstimation> GetAllEstimations()
    {
        return _bidConModelSimpliefier.SimplifieAllEstimations(DatabaseUser.ReadEstimations());
    }
    public SimpleEstimation GetEstimation(string id, EstimationImportSettings settings)
    {
        return _bidConModelSimpliefier.SimplifieEstimation(DatabaseUser.ReadEstimation(id), settings);
    }
}
