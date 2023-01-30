using BidCon.SDK;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.RulesEngine;
public interface IEstimationItemRule
{
    bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine);
}
