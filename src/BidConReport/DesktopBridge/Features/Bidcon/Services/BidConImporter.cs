using BidCon.SDK.Database;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.Services;
public class BidConImporter : IBidConImporter
{
    private readonly IBidConConfigProvider _bidConConfigProvider;
    private DatabaseUser? _databaseUser;
    public BidConImporter(IBidConConfigProvider bidConConfigProvider)
    {
        _bidConConfigProvider = bidConConfigProvider;
    }
    private DatabaseUser DatabaseUser
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
    //TODO mby this locks the user to 1 desktop app
    private void LoginUser()
    {
        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromIni();
        _databaseUser = app.Login(_bidConConfigProvider.GetUserName(), _bidConConfigProvider.GetPassword());
    }
    public DatabaseFolder GetDatabaseFolder()
    {
        return DatabaseUser.ReadEstimations();
    }
    public BidCon.SDK.Estimation GetEstimation(string id)
    {
        return DatabaseUser.ReadEstimation(id);
    }
}
