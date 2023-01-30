using BidCon.SDK;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.RulesEngine;
public interface IEstimationItemRulesEngine
{
    bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings);
}