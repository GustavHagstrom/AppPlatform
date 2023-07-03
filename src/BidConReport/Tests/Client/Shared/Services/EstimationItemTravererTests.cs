using BidConReport.Client.Shared.Services;
using BidConReport.Shared.Entities;
using NUnit.Framework;
using System.Text.Json;

namespace BidconReport.Tests.Client.Shared.Services;
public class EstimationItemTravererTests
{
    private Estimation? _EstimationData;

    [SetUp]
    public void SetUp()
    {
        var jsonFIlePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "EstimationSample.json");
        var jsonData = File.ReadAllText(jsonFIlePath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _EstimationData = JsonSerializer.Deserialize<Estimation>(jsonData, options);
    }
    [Test]
    public void ShouldIterateEveryItem()
    {
        //arrange
        var traverser = new EstimationItemTraverser();

        //act
        var itemList = traverser.GetAllEstimationItems(_EstimationData!).ToList();
        var itemListDistinct = itemList.Distinct().ToList();

        //asser
        Assert.That(itemList.Count, Is.EqualTo(10));
        Assert.That(itemListDistinct.Count, Is.EqualTo(10));
    }
    [Test]
    public void ShouldFindElement()
    {
        //arrange
        var traverser = new EstimationItemTraverser();

        //act
        var itemList = traverser.GetAllEstimationItems(_EstimationData!).ToList();

        //asser
        for (int i = 1; i <= itemList.Count; i++)
        {
            var foundItem = traverser.FindItem(_EstimationData!, i);
            Assert.NotNull(foundItem);
            Assert.That(foundItem.RowNumber, Is.EqualTo(i));
        }
    }
}