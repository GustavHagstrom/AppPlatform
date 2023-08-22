using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Services;

namespace BidconReport.Tests.DirectAccess.Services;
public class EstimationQueryServiceTests
{
    private class CredProvider : IDatabaseCredentialsService
    {
        //public string Get()
        //{
        //    //return "Data Source=RHUSAPP02\\ELECOSOFT;Initial Catalog=BidConEstimation;Connect Timeout = 10;uid=sa;pwd=Putlig@15;TrustServerCertificate=True";
        //    return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BidconEstimationDB;Integrated Security=True;Connect Timeout=5;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        //}

        public async Task<DatabaseCredentials> GetAsync()
        {
            //return await Task.FromResult(new DatabaseCredentials("MSSQLLocalDB", "BidconEstimationDB", "user", "someHshe", false));
            return await Task.FromResult(new DatabaseCredentials("RHUSAPP02\\ELECOSOFT", "BidConEstimation", "sa", "VX3EEWKNQrrBQp+52Ct5Gw==", true));
        }
    }



    private readonly EstimationQueryService _service = new(new ConnectionStringBuilder(new CredProvider()));

    [Test]
    public async Task EstimationResult()
    {
        var estimationService = new DirectEstimationService(_service);
        var estimationId = "7E3C42C5-60B1-424E-9787-FD892E819066";

        var result = await estimationService.GetEstimationAsync(estimationId);

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
        var result = await _service.GetFolderBatchAsync();

        Assert.IsNotNull(result);
    }
}
