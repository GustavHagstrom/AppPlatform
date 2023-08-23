﻿using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BidConReport.BidconDatabaseAccess.Services;
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
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, E.CurrentVersion, EV.EstCurrency as Currency FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and E.CurrentVersion = EV.Version WHERE E.EstimationId = @Id;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, Active as IsActive, RowType, SheetType, LayerType, Version, RevisionCode FROM EstimationSheet WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons, LayerType, Version FROM MELayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons, Version FROM DELayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, LayerID, IsActive, Cons, ConsFactor, Waste, Version FROM PRLayer WHERE EstimationID = @Id;
SELECT ID, EstimationID, Description, Unit, Price, Version FROM Resource WHERE EstimationID = @Id;
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
                return new EstimationBatch(
                    estimation,
                    sheets.ToList(),
                    mixedLayers.ToList(),
                    designElementLayers.ToList(),
                    workResultLayers.ToList(),
                    resources.ToList());
            }
        }
    }
    public async Task<IEnumerable<EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds)
    {
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, E.CurrentVersion, EV.EstCurrency as Currency FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and E.CurrentVersion = EV.Version WHERE E.EstimationId IN @Ids;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, Active as IsActive, RowType, SheetType, LayerType, Version, RevisionCode FROM EstimationSheet WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons, LayerType, Version FROM MELayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons, Version FROM DELayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, LayerID, IsActive, Cons, ConsFactor, Waste, Version FROM PRLayer WHERE EstimationID IN @Ids;
SELECT ID, EstimationID, Description, Unit, Price, Version FROM Resource WHERE EstimationID IN @Ids;
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

                var batches = new List<EstimationBatch>();
                var estimationResultsMap = estimationResults.ToLookup(er => er.EstimationID);
                foreach (var estimationId in estimationIds.Select(x => Guid.Parse(x)))
                {
                    var sheets = sheetResults.Where(sr => sr.EstimationId == estimationId).ToList();
                    var mixedLayers = mixedLayerResults.Where(mlr => mlr.EstimationId == estimationId).ToList();
                    var designElementLayers = designElementLayerResults.Where(delr => delr.EstimationId == estimationId).ToList();
                    var workResultLayers = workResultLayerResults.Where(wrlr => wrlr.EstimationId == estimationId).ToList();
                    var resources = resourceResults.Where(rr => rr.EstimationId == estimationId).ToList();

                    var estimation = estimationResultsMap[estimationId].FirstOrDefault();
                    if (estimation is not null)
                    {
                        batches.Add(new EstimationBatch(
                        estimation,
                        sheets,
                        mixedLayers,
                        designElementLayers,
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
