using BidConReport.Client.Shared.Services;
using BidConReport.Shared.Entities;
using System.Text.Json;

namespace BidconReport.Tests.Client.Shared.Services;
public class EstimationParentReferencerTests
{
    private Estimation? _EstimationData;

    [SetUp]
    public void SetUp()
    {
        var jsonFIlePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "EstimationSample.json");
        var jsonData = File.ReadAllText(jsonFIlePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
        //var testData = JsonSerializer.Serialize(new Estimation
        //{
        //    BidConId = "test",
        //    SelectionTags = new List<string>(),
        //    CostBeforeChanges = 0,
        //    CreationDate = DateTime.Now,
        //    Currency = "SEK",
        //    Id = Guid.Empty,
        //    Items = new List<EstimationItem>(),
        //    LockedCategories = new List<LockedCategory>(),
        //    Name = "test",
        //    OrganizationId = "test",
        //    QuickTags = new List<string>(),
        //});
        _EstimationData = JsonSerializer.Deserialize<Estimation>(jsonData, options);
    }
    [Test]
    public void ParentReferencesShouldBeSet()
    {
        //arrange
        var referencer = new EstimationParentReferencer();
        var traverser = new EstimationItemTraverser();

        //act
        referencer.SetAllParentReferences(_EstimationData!);

        //assert
        foreach (var rootElement in _EstimationData!.Items)
        {
            Assert.That(rootElement.Parent, Is.EqualTo(null));
        }
        foreach (var item in traverser.GetAllEstimationItemsItems(_EstimationData!).Where(x => x.RowNumber != 1 || x.RowNumber != 4))
        {
            Assert.IsNotNull(item.Parent);
        }
    }
}
