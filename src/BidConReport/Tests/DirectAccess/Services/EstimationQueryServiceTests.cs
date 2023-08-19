using BidConReport.DirectAccess.Services;

namespace BidconReport.Tests.DirectAccess.Services;
public class EstimationQueryServiceTests
{
    private class CnnProvider : IConnectionstringProvider
    {
        public string Get()
        {
            return "Data Source=RHUSAPP02\\ELECOSOFT;Initial Catalog=BidConEstimation;Connect Timeout = 10;uid=sa;pwd=Putlig@15;TrustServerCertificate=True";
            //return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BidconEstimationDB;Integrated Security=True;Connect Timeout=5;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }
    }
    private readonly EstimationQueryService _service = new(new CnnProvider());

    [Test]
    public async Task EstimationResult()
    {
        var builder = new EstimationBuilder();
        var estimationId = "26AC7D2D-1500-440A-9915-938162AF0A94";

        var result = await _service.GetEstimationBatchAsync(estimationId);
        var estimation = builder.Build(result);

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
