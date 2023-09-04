﻿using BidConReport.Client.Shared.BidconAccess.Enteties;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BidConReport.Client.Shared.BidconAccess.Services;
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
    public async Task<BC_EstimationBatch> GetEstimationBatchAsync(string estimationId)
    {
        //TODO add ResourceFactor, ATA, ATAFactors, only include active items?
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, EV.EstCurrency as Currency, EV.ObjectFactor, EV.TenderTotal, EV.TenderType, EV.State as EstimationState FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and EV.Version = E.CurrentVersion WHERE E.EstimationId = @Id;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, RowType, SheetType, LayerType, RevisionCode, Position, PMATANum, AddedInPhase, UnitPriceManual FROM EstimationSheet WHERE EstimationID = @Id AND Active = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons, LayerType FROM MELayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons FROM DELayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, LayerID, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID = @Id AND IsActive = 1 AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT ID, EstimationID, Description, ResourceType, Price FROM Resource WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, ResourceType, Factor FROM ResourceFactors WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, PMATANum, ID AS Name, Description FROM PM_ATA WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
SELECT EstimationID, PMATANum, ResourceType, RemovalPer as RemovealPercent, RemovalExpensePer AS RemovalExpensePercent, AdditionalPer AS AdditionalPercent, AdditionalExpensePer AS AdditionalExpensePercent FROM PM_ATAFactor WHERE EstimationID = @Id AND Version = (SELECT CurrentVersion FROM Estimation WHERE EstimationID = @Id);
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Id = estimationId.ToString() }))
            {
                var estimation = await multi.ReadFirstAsync<BC_Estimation>();
                var sheets = await multi.ReadAsync<BC_EstimationSheet>();
                var mixedLayers = await multi.ReadAsync<BC_MixedElementLayer>();
                var designElementLayers = await multi.ReadAsync<BC_DesignElementLayer>();
                var workResultLayers = await multi.ReadAsync<BC_WorkResultLayer>();
                var resources = await multi.ReadAsync<BC_Resource>();
                var resourceFactors = await multi.ReadAsync<BC_ResourceFactor>();
                var ataResults = await multi.ReadAsync<BC_ATA>();
                var ataFactorResults = await multi.ReadAsync<BC_ATAFactor>();
                return new BC_EstimationBatch(
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
    public async Task<IEnumerable<BC_EstimationBatch>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds)
    {
        var sql = @"
SELECT E.EstimationID, E.Name, E.Description, E.Customer, E.Place, E.HandlingOfficer, E.ConfirmationOfficer, E.IsLocked, E.FolderNum, EV.EstCurrency as Currency, EV.ObjectFactor, EV.TenderTotal, EV.TenderType, EV.State as EstimationState FROM Estimation AS E LEFT JOIN EstimationVersion AS EV ON E.EstimationID = EV.EstimationID and EV.Version = E.CurrentVersion WHERE E.EstimationId IN @Ids;
SELECT EstimationID, LayerID, RowNum as Row, FatherRowNum as ParentRow, RowDescription as Description, Remark, Quantity, Unit, RowType, SheetType, LayerType, RevisionCode, Position, PMATANum, AddedInPhase, UnitPriceManual FROM EstimationSheet WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = EstimationSheet.EstimationID);
SELECT ID, EstimationID, LayerID, Cons, LayerType FROM MELayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = MELayer.EstimationID);
SELECT ID, EstimationID, LayerID, Cons FROM DELayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = DELayer.EstimationID);
SELECT ID, EstimationID, LayerID, Cons, ConsFactor, Waste FROM PRLayer WHERE EstimationID IN @Ids AND IsActive = 1 AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PRLayer.EstimationID);
SELECT ID, EstimationID, Description, ResourceType, Price FROM Resource WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = Resource.EstimationID);
SELECT EstimationID, ResourceType, Factor FROM ResourceFactors WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = ResourceFactors.EstimationId);
SELECT EstimationID, PMATANum, ID AS Name, Description FROM PM_ATA WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PM_ATA.EstimationID);
SELECT EstimationID, PMATANum, ResourceType, RemovalPer as RemovealPercent, RemovalExpensePer AS RemovalExpensePercent, AdditionalPer AS AdditionalPercent, AdditionalExpensePer AS AdditionalExpensePercent FROM PM_ATAFactor WHERE EstimationID IN @Ids AND Version IN (SELECT CurrentVersion FROM Estimation WHERE EstimationID = PM_ATAFactor.EstimationID);
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Ids = estimationIds }))
            {
                var estimationResults = await multi.ReadAsync<BC_Estimation>();
                var sheetResults = await multi.ReadAsync<BC_EstimationSheet>();
                var mixedLayerResults = await multi.ReadAsync<BC_MixedElementLayer>();
                var designElementLayerResults = await multi.ReadAsync<BC_DesignElementLayer>();
                var workResultLayerResults = await multi.ReadAsync<BC_WorkResultLayer>();
                var resourceResults = await multi.ReadAsync<BC_Resource>();
                var resourceFactorsResults = await multi.ReadAsync<BC_ResourceFactor>();
                var ataResults = await multi.ReadAsync<BC_ATA>();
                var ataFactorResults = await multi.ReadAsync<BC_ATAFactor>();

                var batches = new List<BC_EstimationBatch>();
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
                        batches.Add(new BC_EstimationBatch(
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

    public async Task<IEnumerable<BC_Estimation>> GetEstimationListAsync()
    {
        var sql = "SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            return await cnn.QueryAsync<BC_Estimation>(sql);
        }
    }
    public async Task<BC_EstimationFolderBatch> GetFolderBatchAsync()
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation;
SELECT FolderNum, ParentNum, Name FROM EstimationFolder;
";
        using (IDbConnection cnn = new SqlConnection(await GetLasyConnectionString()))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql))
            {
                var estimations = await multi.ReadAsync<BC_Estimation>();
                var folders = await multi.ReadAsync<BC_EstimationFolder>();
                return new BC_EstimationFolderBatch(estimations, folders);
            }
        }
    }
}
