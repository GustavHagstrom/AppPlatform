using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BidConReport.DirectAccess.Services;
internal class EstimationQueryService : IEstimationQueryService
{
    private readonly string _connectionString;

    public EstimationQueryService(IConnectionStringBuilder connectionStringBuilder)
    {
        _connectionString = connectionStringBuilder.BuildAsync().Result;
    }
    public async Task<EstimationBatch> GetEstimationBatchAsync(string estimationId)
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum FROM Estimation WHERE EstimationId = @Id;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, Active as IsActive, RowType, SheetType, LayerType FROM EstimationSheet WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons, LayerType FROM MELayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, Unit FROM DE WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons FROM DELayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, Unit FROM PR WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, Description, Unit, Price FROM Resource WHERE EstimationID = @Id;
";
        using (IDbConnection cnn = new SqlConnection(_connectionString))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Id = estimationId.ToString() }))
            {
                var estimation = await multi.ReadFirstAsync<EstimationResult>();
                var sheets = await multi.ReadAsync<EstimationSheetResult>();
                var mixedLayers = await multi.ReadAsync<MixedElementLayerResult>();
                var designElements = await multi.ReadAsync<DesignElementResult>();
                var designElementLayers = await multi.ReadAsync<DesignElementLayerResult>();
                var workResults = await multi.ReadAsync<WorkResultResult>();
                var workResultLayers = await multi.ReadAsync<WorkResultLayerResult>();
                var resources = await multi.ReadAsync<ResourceResult>();
                return new EstimationBatch(
                    estimation,
                    sheets.ToList(),
                    mixedLayers.ToList(),
                    designElements.ToList(),
                    designElementLayers.ToList(),
                    workResults.ToList(),
                    workResultLayers.ToList(),
                    resources.ToList());
            }
        }
    }
    public async Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds)
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum FROM Estimation WHERE EstimationId IN @Ids;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, Active as IsActive, RowType, SheetType, LayerType FROM EstimationSheet WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons, LayerType FROM MELayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, Unit FROM DE WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons FROM DELayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, Unit FROM PR WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, Description, Unit, Price FROM Resource WHERE EstimationID IN @Ids;
";
        using (IDbConnection cnn = new SqlConnection(_connectionString))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Ids = estimationIds }))
            {
                var estimationResults = await multi.ReadAsync<EstimationResult>();
                var sheetResults = await multi.ReadAsync<EstimationSheetResult>();
                var mixedLayerResults = await multi.ReadAsync<MixedElementLayerResult>();
                var designElementResults = await multi.ReadAsync<DesignElementResult>();
                var designElementLayerResults = await multi.ReadAsync<DesignElementLayerResult>();
                var workResultResults = await multi.ReadAsync<WorkResultResult>();
                var workResultLayerResults = await multi.ReadAsync<WorkResultLayerResult>();
                var resourceResults = await multi.ReadAsync<ResourceResult>();

                var batches = new List<EstimationBatch>();
                var estimationResultsMap = estimationResults.ToLookup(er => er.EstimationID);
                foreach (var estimationId in estimationIds.Select(x => Guid.Parse(x)))
                {
                    var sheets = sheetResults.Where(sr => sr.EstimationId == estimationId).ToList();
                    var mixedLayers = mixedLayerResults.Where(mlr => mlr.EstimationId == estimationId).ToList();
                    var designElements = designElementResults.Where(der => der.EstimationId == estimationId).ToList();
                    var designElementLayers = designElementLayerResults.Where(delr => delr.EstimationId == estimationId).ToList();
                    var workResults = workResultResults.Where(wrr => wrr.EstimationId == estimationId).ToList();
                    var workResultLayers = workResultLayerResults.Where(wrlr => wrlr.EstimationId == estimationId).ToList();
                    var resources = resourceResults.Where(rr => rr.EstimationId == estimationId).ToList();

                    var estimation = estimationResultsMap[estimationId].FirstOrDefault();
                    if (estimation is not null)
                    {
                        batches.Add(new EstimationBatch(
                        estimation,
                        sheets,
                        mixedLayers,
                        designElements,
                        designElementLayers,
                        workResults,
                        workResultLayers,
                        resources));
                    }
                }

                return batches;
            }
        }
    }

    public async Task<IEnumerable<EstimationResult>> GetEstimationListAsync()
    {
        var sql = "SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum FROM Estimation";
        using (IDbConnection cnn = new SqlConnection(_connectionString))
        {
            return await cnn.QueryAsync<EstimationResult>(sql);
        }
    }
    public async Task<EstimationFolderBatch> GetFolderBatchAsync()
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum FROM Estimation;
SELECT FolderNum, ParentNum, Name FROM EstimationFolder;
";
        using (IDbConnection cnn = new SqlConnection(_connectionString))
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
