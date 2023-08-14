using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public class EstimationFactory : IEstimationFactory
{
    private readonly IEstimationItemsFactory _estimationItemsFactory;

    public EstimationFactory(IEstimationItemsFactory estimationItemsFactory)
    {
        _estimationItemsFactory = estimationItemsFactory;
    }
    public Shared.DTOs.EstimationDTO Create(BidCon.SDK.Estimation estimation, EstimationImportSettingsDTO settings)
    {
        
        var costFactor = GetSummarySheetResourceAccountValue(settings.CostFactorAccount, estimation);
        var costBeforeChanges = GetSummarySheetResourceAccountValue(settings.CostBeforeChangesAccount, estimation);
        var endPageNetCost = GetSummarySheetResourceAccountValue(settings.NetCostAccount, estimation);
        int startRow = 0;

        return new Shared.DTOs.EstimationDTO
        {
            Id = Guid.NewGuid(),
            BidConId = estimation.ID.ToString(),
            OrganizationId = settings.OrganizationId,
            Name = estimation.Name,
            Description = estimation.Description,
            CreationDate = DateTime.Now,
            CostBeforeChanges = costBeforeChanges + (estimation.NetSheet.TotalCost - endPageNetCost) * costFactor,
            Currency = estimation.Currency,
            QuickTags = settings.QuickTags?.ToArray() ?? Array.Empty<string>(),
            SelectionTags = settings.SelectionTags?.ToArray() ?? Array.Empty<string>() ,
            Items = _estimationItemsFactory.Create(estimation.NetSheet, settings, ref startRow, costFactor),
            LockedCategories = CreateLockedCategories(estimation, settings, costFactor).ToList(),
        };
    }
    private static double GetSummarySheetResourceAccountValue(string account, BidCon.SDK.Estimation estimation)
    {
        var allSummarySheetResources = GetResources(estimation.SummarySheet);
        var accountSpecifiResources = allSummarySheetResources!.Where(x => x.Account.Code == account).ToList();
        if (accountSpecifiResources.Count == 0) throw new Exception($"""Required resource with account "{account}" does not exist""");
        if (accountSpecifiResources.Count > 1) throw new Exception($"""Required resource with account "{account}" has more than one occurance""");
        return accountSpecifiResources.First().TotalCost;
    }
    private IEnumerable<LockedCategoryDTO> CreateLockedCategories(BidCon.SDK.Estimation estimation, EstimationImportSettingsDTO settings, double costFactor)
    {
        if (estimation.LockedStages is not null)
        {
            foreach (var category in estimation.LockedStages.Items)
            {
                yield return new LockedCategoryDTO
                {
                    Name = category.Name,
                    LockedStages = CreateLockedStages(category, settings, costFactor).ToList(),
                };
            }
        }
    }
    private IEnumerable<LockedStageDTO> CreateLockedStages(BidCon.SDK.EstimationItem category, EstimationImportSettingsDTO settings, double costFactor)
    {
        int startRow = 0;
        foreach (var stage in category.Items)
        {
            yield return new LockedStageDTO
            {
                Name = stage.Name,
                Items = _estimationItemsFactory.Create(stage, settings, ref startRow, costFactor)
            };
        }
    }
    private static List<Resource> GetResources(BidCon.SDK.EstimationItem estimationItem)
    {
        
        var resources = new List<Resource>();
        if (estimationItem is null) return resources;

        if (estimationItem is Resource resource)
        {
            resources.Add(resource);
            return resources;
        }
        foreach (var item in estimationItem.Items)
        {
            resources.AddRange(GetResources(item));
        }
        return resources;
    }
}
