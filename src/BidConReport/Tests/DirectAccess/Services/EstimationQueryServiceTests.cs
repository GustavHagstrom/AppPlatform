using BidConReport.DirectAccess.Services;

namespace BidconReport.Tests.DirectAccess.Services;
public class EstimationQueryServiceTests
{
    private class CnnProvider : IConnectionstringProvider
    {
        public string Get()
        {
            //return "Data Source=RHUSAPP02\\ELECOSOFT;Initial Catalog=BidConEstimation;Connect Timeout = 10;uid=sa;pwd=Putlig@15;TrustServerCertificate=True";
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BidconEstimationDB;Integrated Security=True;Connect Timeout=5;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
    }
    private readonly EstimationQueryService _service = new(new CnnProvider());

    [Test]
    public async Task EstimationResult()
    {
        var estimationId = "2988490F-15B7-4C0B-AC22-CDE71DAC9E02";

        var result = await _service.GetEstimationBatchAsync(estimationId);

        Assert.IsNotNull(result);
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
        var result = await _service.GetFolderBatch();

        Assert.IsNotNull(result);
    }
}
