using BidconLink.Services;
using SharedLibrary.DTOs.BidconAccess;
using System.Text.Json;

namespace Tests.BidconLink.Services;
public class EstimationQueryServiceTests
{
 

    private readonly BC_DatabaseCredentialsDto _localCredential = new ("(localdb)\\MSSQLLocalDB", "BidconEstimation", "user", "someHash", false);
    private readonly BC_DatabaseCredentialsDto _rvhCredential = new("RHUSAPP02\\ELECOSOFT", "BidConEstimation", "sa", "VX3EEWKNQrrBQp+52Ct5Gw==", true);
    private BC_DatabaseCredentialsDto _credentials => _localCredential;


    private readonly EstimationQueryService _service = new(new ConnectionstringService());

    [Test]
    public async Task EstimationBatch()
    {
        var estimationId = "E2217CB2-3C68-4EC3-91CD-DAF28F55FE39";

        var queryResult = await _service.GetEstimationBatchAsync(estimationId, _credentials);
        var json = JsonSerializer.Serialize(queryResult);
        //Assert.That(queryResult, Is.Not.Null);
    }
    [Test]
    public async Task EstimationBatches()
    {
        var ids = new string[]
        {
            "7FF66EAD-FD4D-4D90-8295-00A8A977E2AA",
            "11584A74-756D-4853-8018-3B86101ECB0A",
            "834F0AA1-29A5-464A-BA60-18745697EEB7",
            "D82C2136-D5FD-4588-A00F-37143A7F64C1",
            "FFD87062-986B-4CE1-B9DC-42E831775506",
            "B91DE8B0-BE91-43D6-B6EB-7B4A90BE2EB0",
            "82AD7F4F-0569-4E83-8515-59FB0D2367CB",
            "7ACB823C-4551-4A0C-8BAC-B0B715EF3937",
            "7E90F642-8C9F-4D77-93AA-365D3544F0AC",
            "A310CBA0-1CFE-4229-A0AA-4E6C4ECB1318",
            "AA0C5087-7560-4EEE-A930-4FB572BCAC78",
            "282EBA63-5068-4CDB-8A00-BCD8B66584AC",
            "C00F3008-2F32-43FC-910F-50E32CADA1FA",
            "E2225D16-F904-4388-81E5-431246A5ECFB",
        };

        var results = await _service.GetEstimationBatchesAsync(ids, _credentials);
        foreach (var result in results)
        {
            Assert.That(result, Is.Not.Null);
        }
    }
    [Test]
    public async Task EstimationResultList()
    {
        var result = await _service.GetEstimationListAsync(_credentials);

        Assert.IsNotNull(result);
    }
    [Test]
    public async Task EstimationFolderBatch()
    {
        var result = await _service.GetFolderBatchAsync(_credentials);

        Assert.IsNotNull(result);
    }
}
