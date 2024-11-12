using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Core.Enteties.EstimationEnteties;
using BidCon.SDK.Database;
using System.Security.Claims;

namespace AppPlatform.BidconDatabaseAccess.SdkAccess.Services;
internal class BidconSdkAccess : IBidconAccess
{
    private readonly Lazy<Task<DatabaseUser>> _lazyUser;
    private readonly ISdkCredentialsService _sdkCredentialsService;

    public BidconSdkAccess(ISdkCredentialsService sdkCredentialsService)
    {
        _lazyUser = new Lazy<Task<DatabaseUser>>(UserLazyLoadAsync);
        _sdkCredentialsService = sdkCredentialsService;
    }

    public async Task<Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims)
    {
        var user = await _lazyUser.Value;
        var bEstimation = user.ReadEstimation(estimationId);
        throw new NotImplementedException();
    }

    public async Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims)
    {
        var user = await _lazyUser.Value;
        var dbFolder = user!.ReadEstimations();
        var folder = CreateFolder(dbFolder);
        return folder;
    }

    private Folder CreateFolder(DatabaseFolder root)
    {
        var folder = new Folder
        {
            FolderNum = root.FolderNum,
            ParentNum = root.Parent.FolderNum,
            Name = root.Name,
            DbEstimations = new List<EstimationInfo>(),
            SubFolders = new List<Folder>()
        };
        foreach (var estimation in root.Estimations)
        {
            folder.DbEstimations.Add(CreateEstimationInfo(estimation, folder.FolderNum));
        }
        foreach (var subFolder in root.Folders)
        {
            folder.SubFolders.Add(CreateFolder(subFolder));
        }
        return folder;
    }
    private EstimationInfo CreateEstimationInfo(DatabaseEstimation dbEstimation, int folderNum)
    {
        return new EstimationInfo
        {
            FolderNum = folderNum,
            Name = dbEstimation.Name,
            Description = dbEstimation.Description,
            Id = dbEstimation.ID,
        };
    }
    private async Task<DatabaseUser> UserLazyLoadAsync()
    {
        var credentials = await _sdkCredentialsService.GetSdkCredentialsAsync();
        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromConfig(credentials.ConfigPath);
        var user = app.Login(credentials.User, credentials.Password);
        return user;
    }
}
