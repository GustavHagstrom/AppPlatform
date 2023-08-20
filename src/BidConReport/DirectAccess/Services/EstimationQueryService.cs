using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BidConReport.DirectAccess.Services;
public class EstimationQueryService : IEstimationQueryService
{
    private readonly string _connectionString;

    public EstimationQueryService(IConnectionstringProvider connectionstringProvider)
    {
        _connectionString = connectionstringProvider.Get();
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
    public async Task<IEnumerable<EstimationResult>> GetEstimationListAsync()
    {
        var sql = "SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum FROM Estimation";
        using (IDbConnection cnn = new SqlConnection(_connectionString))
        {
            return await cnn.QueryAsync<EstimationResult>(sql);
        }
    }
    public async Task<EstimationFolderBatch> GetFolderBatch()
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
