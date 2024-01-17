﻿using Dapper;
using Microsoft.Data.SqlClient;
using SharedLibrary.DTOs.BidconAccess;
using System.Data;

namespace AppPlatform.BidconDataAccess;
public class EstimationQueryService : IEstimationQueryService
{
    private readonly IConnectionstringService _connectionStringBuilder;
    public EstimationQueryService(IConnectionstringService connectionStringBuilder)
    {
        _connectionStringBuilder = connectionStringBuilder;
    }

    public async Task<BC_EstimationBatchDto> GetEstimationBatchAsync(string estimationId, string? organization = null)
    {
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
        using (IDbConnection cnn = new SqlConnection(await _connectionStringBuilder.BuildAsync(organization)))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Id = estimationId.ToString() }))
            {
                var estimation = await multi.ReadFirstAsync<BC_EstimationDto>();
                var sheets = await multi.ReadAsync<BC_EstimationSheetDto>();
                var mixedLayers = await multi.ReadAsync<BC_MixedElementLayerDto>();
                var designElementLayers = await multi.ReadAsync<BC_DesignElementLayerDto>();
                var workResultLayers = await multi.ReadAsync<BC_WorkResultLayerDto>();
                var resources = await multi.ReadAsync<BC_ResourceDto>();
                var resourceFactors = await multi.ReadAsync<BC_ResourceFactorDto>();
                var ataResults = await multi.ReadAsync<BC_ATADto>();
                var ataFactorResults = await multi.ReadAsync<BC_ATAFactorDto>();
                return new BC_EstimationBatchDto(
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
    public async Task<IEnumerable<BC_EstimationBatchDto>> GetEstimationBatchesAsync(IEnumerable<string> estimationIds, string? organization = null)
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
        using (IDbConnection cnn = new SqlConnection(await _connectionStringBuilder.BuildAsync(organization)))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql, new { Ids = estimationIds }))
            {
                var estimationResults = await multi.ReadAsync<BC_EstimationDto>();
                var sheetResults = await multi.ReadAsync<BC_EstimationSheetDto>();
                var mixedLayerResults = await multi.ReadAsync<BC_MixedElementLayerDto>();
                var designElementLayerResults = await multi.ReadAsync<BC_DesignElementLayerDto>();
                var workResultLayerResults = await multi.ReadAsync<BC_WorkResultLayerDto>();
                var resourceResults = await multi.ReadAsync<BC_ResourceDto>();
                var resourceFactorsResults = await multi.ReadAsync<BC_ResourceFactorDto>();
                var ataResults = await multi.ReadAsync<BC_ATADto>();
                var ataFactorResults = await multi.ReadAsync<BC_ATAFactorDto>();

                var batches = new List<BC_EstimationBatchDto>();
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
                        batches.Add(new BC_EstimationBatchDto(
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
    public async Task<IEnumerable<BC_EstimationDto>> GetEstimationListAsync(string? organization = null)
    {
        var sql = "SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation";
        using (IDbConnection cnn = new SqlConnection(await _connectionStringBuilder.BuildAsync(organization)))
        {
            return await cnn.QueryAsync<BC_EstimationDto>(sql);
        }
    }
    public async Task<BC_EstimationFolderBatch> GetFolderBatchAsync(string? organization = null)
    {
        var sql = @"
SELECT EstimationID, Name, Description, Customer, Place, HandlingOfficer, ConfirmationOfficer, IsLocked, FolderNum, CurrentVersion FROM Estimation;
SELECT FolderNum, ParentNum, Name FROM EstimationFolder;
";
        using (IDbConnection cnn = new SqlConnection(await _connectionStringBuilder.BuildAsync(organization)))
        {
            using (var multi = await cnn.QueryMultipleAsync(sql))
            {
                var estimations = await multi.ReadAsync<BC_EstimationDto>();
                var folders = await multi.ReadAsync<BC_EstimationFolderDto>();
                return new BC_EstimationFolderBatch(estimations, folders);
            }
        }
    }
}
