﻿using BidConReport.Client.Shared.BidconAccess.Enteties;
using BidConReport.Client.Shared.EstimationProcessing.Services;
using System.Text.Json;

namespace BidconReport.Tests.Client.Shared.Services.EstimationBuilding;
[TestFixture]
public class EstimationBuilderServiceTests
{
    private readonly IEstimationBuilderService _service = new EstimationBuilderService();
    private EstimationBatch _sampleBatch;

    [SetUp]
    public void SetUp()
    {
        var jsonFIlePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "EstimationBatch.json");
        var jsonData = File.ReadAllText(jsonFIlePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _sampleBatch = JsonSerializer.Deserialize<EstimationBatch>(jsonData, options)!;
    }

    [Test]
    public void OneBigTest_ShouldTestEverything()
    {
        var result = _service.Build(_sampleBatch);

    }
}
