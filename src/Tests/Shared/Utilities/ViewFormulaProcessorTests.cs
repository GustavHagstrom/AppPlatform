using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.Utilities;

namespace AppPlatform.Tests.Shared.Utilities;
[TestFixture]
public class ViewFormulaProcessorTests
{
    //Test for basic placeholders
    [TestCase(Placeholders.Estimation.Name, "Name")]
    [TestCase(Placeholders.Estimation.Id, "Id")]
    [TestCase(Placeholders.Estimation.Description, "Description")]
    [TestCase(Placeholders.Estimation.Customer, "Customer")]
    [TestCase(Placeholders.Estimation.Place, "Place")]
    [TestCase(Placeholders.Estimation.HandlingOfficer, "HandlingOfficer")]
    [TestCase(Placeholders.Estimation.ConfirmationOfficer, "ConfirmationOfficer")]
    [TestCase(Placeholders.Estimation.TenderTotal, "1\u00A0000\u00A0000")]
    [TestCase($"{Placeholders.Estimation.Name} - {Placeholders.Estimation.Description}", "Name - Description")]

    public void Process_EstimationName_ReturnsEstimationName(string placeholder, string expected)
    {
        //Arrange
        var estimation = new Estimation
        {
            Id = "Id",
            BidconId = "Id",
            Name = "Name",
            Description = "Description",
            Customer = "Customer",
            Place = "Place",
            HandlingOfficer = "HandlingOfficer",
            ConfirmationOfficer = "ConfirmationOfficer",
            TenderTotal = 1000000.49999
        };
        //Act
        var actual = ViewFormulaProcessor.Process(placeholder, estimation);
        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
