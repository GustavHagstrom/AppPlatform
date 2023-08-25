using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.QueryResults;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BidConReport.BidconAccess.Services.BidconAccess;
public class EstimationQueryService : IEstimationQueryService
{
    private readonly IConnectionstringService _connectionStringBuilder;
    private string? _connectionString;
    private bool _isInitialized = false;

    public EstimationQueryService(IConnectionstringService connectionStringBuilder)
    {
        _connectionStringBuilder = connectionStringBuilder;
    }
    private async Task<string> GetLasyConnectionString()
    {
        if (_isInitialized)
        {
            return _connectionString!;
        }
        else
        {
            _isInitialized = true;
            _connectionString = await _connectionStringBuilder.BuildAsync();
            return _connectionString;
        }
    }
    public async Task<EstimationBatch> GetEstimationBatchAsync(string estimationId)
    {
        //TODO add ResourceFactor, ATA, ATAFactors, only include active items?
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, EV.EstCurrency as Currency, EV.ObjectFactor FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and EV.Version = E.CurrentVersion WHERE E.EstimationId = @Id;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, RowType, SheetType, LayerType, RevisionCode FROM EstimationSheet WHERE EstimationID = @Id AND Active = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons, LayerType FROM MELayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons FROM DELayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, Description, ResourceType, Price FROM Resource WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, ResourceType, Factor FROM ResourceFactors WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, PMATANum, Description FROM PM_ATA WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, PMATANum, ResourceType, RemovalPer as RemovealPercent, RemovalExpensePer AS RemovalExpensePercent, AdditionalPer AS AdditionalPercent, AdditionalExpensePer AS AdditionalExpensePercent FROM PM_ATAFactor WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Id = estimationId.ToString() }))
            {
                var estimation = await multi.ReadFirstAsync<EstimationResult>();
                var sheets = await multi.ReadAsync<EstimationSheetResult>();
                var mixedLayers = await multi.ReadAsync<MixedElementLayerResult>();
                var designElementLayers = await multi.ReadAsync<DesignElementLayerResult>();
                var workResultLayers = await multi.ReadAsync<WorkResultLayerResult>();
                var resources = await multi.ReadAsync<ResourceResult>();
                var resourceFactors = await multi.ReadAsync<ResourceFactorResult>();
                var ataResults = await multi.ReadAsync<ATAResult>();
                var ataFactorResults = await multi.ReadAsync<ATAFactorResult>();
                return new EstimationBatch(
                    estimation,
                    sheets.ToList(),
                    mixedLayers.ToList(),
                    designElementLayers.ToList(),
                    workResultLayers.ToList(),
                    resources.ToList(),
                    resourceFactors.ToList(),
                    ataResults.ToList(),
                    ataFactorResults.ToList());
            }
        }
    }
    public async Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds)
    {
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, EV.EstCurrency as Currency, EV.ObjectFactor FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and EV.Version = E.CurrentVersion WHERE E.EstimationId IN @Ids;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, RowType, SheetType, LayerType, RevisionCode FROM EstimationSheet WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = EstimationSheet.EstimationID);
SELECT ID, EstimationID, LayerID, Cons, LayerType FROM MELayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = MELayer.EstimationID);
SELECT ID, EstimationID, LayerID, Cons FROM DELayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = DELayer.EstimationID);
SELECT ID, EstimationID, LayerID, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PRLayer.EstimationID);
SELECT ID, EstimationID, Description, ResourceType, Price FROM Resource WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = Resource.EstimationID);
SELECT EstimationID, ResourceType, Factor FROM ResourceFactors WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = ResourceFactors.EstimationId);
SELECT EstimationID, PMATANum, Description FROM PM_ATA WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PM_ATA.EstimationID);
SELECT EstimationID, PMATANum, ResourceType, RemovalPer as RemovealPercent, RemovalExpensePer AS RemovalExpensePercent, AdditionalPer AS AdditionalPercent, AdditionalExpensePer AS AdditionalExpensePercent FROM PM_ATAFactor WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PM_ATAFactor.EstimationID);
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Ids = estimationIds }))
            {
                var estimationResults = await multi.ReadAsync<EstimationResult>();
                var sheetResults = await multi.ReadAsync<EstimationSheetResult>();
                var mixedLayerResults = await multi.ReadAsync<MixedElementLayerResult>();
                var designElementLayerResults = await multi.ReadAsync<DesignElementLayerResult>();
                var workResultLayerResults = await multi.ReadAsync<WorkResultLayerResult>();
                var resourceResults = await multi.ReadAsync<ResourceResult>();
                var resourceFactorsResults = await multi.ReadAsync<ResourceFactorResult>();
                var ataResults = await multi.ReadAsync<ATAResult>();
                var ataFactorResults = await multi.ReadAsync<ATAFactorResult>();

                var batches = new List<EstimationBatch>();
                var estimationResultsMap = estimationResults.ToLookup(er => er.EstimationID);
                foreach (var estimationId in estimationIds.Select(x => Guid.Parse(x)))
                {
                    var sheets = sheetResults.Where(sr => sr.EstimationId == estimationId).ToList();
                    var mixedLayers = mixedLayerResults.Where(mlr => mlr.EstimationId == estimationId).ToList();
                    var designElementLayers = designElementLayerResults.Where(delr => delr.EstimationId == estimationId).ToList();
                    var workResultLayers = workResultLayerResults.Where(wrlr => wrlr.EstimationId == estimationId).ToList();
                    var resources = resourceResults.Where(rr => rr.EstimationId == estimationId).ToList();
                    var resourceFactors = resourceFactorsResults.Where(rf => rf.EstimationId == estimationId).ToList();
                    var ata = ataResults.Where(rf => rf.EstimationId == estimationId).ToList();
                    var ataFactor = ataFactorResults.Where(rf => rf.EstimationId == estimationId).ToList();

                    var estimation = estimationResultsMap[estimationId].FirstOrDefault();
                    if (estimation is not null)
                    {
                        batches.Add(new EstimationBatch(
                        estimation,
                        sheets,
                        mixedLayers,
                        designElementLayers,
                        workResultLayers,
                        resources,
                        resourceFactors,
                        ata,
                        ataFactor));
                    }
                }
                return batches;
            }
        }
    }

    public async Task<IEnumerable<EstimationResult>> GetEstimationListAsync()
    {
        var sql = "SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            return await cnn.QueryAsync<EstimationResult>(sql);
        }
    }
    public async Task<EstimationFolderBatch> GetFolderBatchAsync()
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation;
SELECT FolderNum, ParentNum, Name FROM EstimationFolder;
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql))
            {
                var estimations = await multi.ReadAsync<EstimationResult>();
                var folders = await multi.ReadAsync<EstimationFolderResult>();
                return new EstimationFolderBatch(estimations, folders);
            }
        }
    }
}
