﻿using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enums;
using BidConReport.BidconDatabaseAccess.Services.BidconAccess;
using BidConReport.BidconDatabaseAccess.Services.EstimationBuilding;

namespace BidconReport.Tests.DirectAccess.Services;
public class EstimationQueryServiceTests
{
    private class CredProvider : IDatabaseCredentialsService
    {
        public async Task<DatabaseCredentials> GetAsync()
        {
            return await Task.FromResult(new DatabaseCredentials("(localdb)\\MSSQLLocalDB", "BidconEstimation", "user", "someHash", false));
            return await Task.FromResult(new DatabaseCredentials("RHUSAPP02\\ELECOSOFT", "BidConEstimation", "sa", "VX3EEWKNQrrBQp+52Ct5Gw==", true));
        }
    }



    private readonly EstimationQueryService _service = new(new ConnectionstringService(new CredProvider()));

    [Test]
    public async Task EstimationBatch()
    {
        //var costService = new EstimationCostService();
        //var estimationService = new DirectEstimationService(_service);
        var builder = new EstimationBuilder(new LayerdItemCalculator());
        var estimationId = "7E3C42C5-60B1-424E-9787-FD892E819066";

        //var result = await estimationService.GetEstimationAsync(estimationId);
        var queryResult = await _service.GetEstimationBatchAsync(estimationId);
        var buildResult = builder.Build(queryResult);
        var unbuiltSheetList = queryResult.SheetResults.Where(x => x.SheetType == (int)SheetType.NetSheet).OrderBy(x => x.Row).ToList();
        var builtSheetList = buildResult.NetSheet.AllInOrder.ToList();
        //var unitCost = costService.UnitCosts(result.NetSheet, queryResult);
        //var totalCosts = result.NetSheet.SheetItems.Select(x => costService.TotalCosts(x, queryResult)).ToList();
        //var totalSums = totalCosts.Select(x => x.Sum(x => x.Value)).ToList();// .Sum(x => x.Value);

        Assert.That(unbuiltSheetList.Count, Is.EqualTo(builtSheetList.Count));
    }
    [Test]
    public async Task EstimationBatches()
    {
        //var estimationService = new DirectEstimationService(_service);
        //var ids = new string[]
        //{
        //    "7FF66EAD-FD4D-4D90-8295-00A8A977E2AA",
        //    "11584A74-756D-4853-8018-3B86101ECB0A",
        //    "834F0AA1-29A5-464A-BA60-18745697EEB7",
        //    "D82C2136-D5FD-4588-A00F-37143A7F64C1",
        //    "FFD87062-986B-4CE1-B9DC-42E831775506",
        //    "B91DE8B0-BE91-43D6-B6EB-7B4A90BE2EB0",
        //    "82AD7F4F-0569-4E83-8515-59FB0D2367CB",
        //    "7ACB823C-4551-4A0C-8BAC-B0B715EF3937",
        //    "7E90F642-8C9F-4D77-93AA-365D3544F0AC",
        //    "A310CBA0-1CFE-4229-A0AA-4E6C4ECB1318",
        //    "AA0C5087-7560-4EEE-A930-4FB572BCAC78",
        //    "282EBA63-5068-4CDB-8A00-BCD8B66584AC",
        //    "C00F3008-2F32-43FC-910F-50E32CADA1FA",
        //    "E2225D16-F904-4388-81E5-431246A5ECFB",
        //};

        //var results = await estimationService.GetEstimationsAsync(ids);

        //foreach (var result in results) 
        //{
        //    Assert.That(result, Is.Not.Null);
        //}
    }
    [Test]
    public async Task EstimationResultList()
    {
        var result = await _service.GetEstimationListAsync();

        Assert.IsNotNull(result);
    }
    [Test]
    public async Task EstimationFolderBatch()
    {
        var result = await _service.GetFolderBatchAsync();

        Assert.IsNotNull(result);
    }
}
