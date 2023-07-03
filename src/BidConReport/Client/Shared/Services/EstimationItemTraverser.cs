using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;

public class EstimationItemTraverser : IEstimationItemTraverser
{
    public EstimationItem? FindItem(Estimation estimation, int row)
    {
        return FindItem(estimation.Items, row);
    }
    public IEnumerable<EstimationItem> GetAllEstimationItemsItems(Estimation estimation)
    {
        var itemList = new List<EstimationItem>();
        foreach (var baseNode in estimation.Items)
        {
            foreach (var item in GetAllItems(baseNode))
            {
                yield return item;
            }
        }
    }
    private EstimationItem? FindItem(ICollection<EstimationItem> items, int row)
    {
        EstimationItem currentItem;
        for (int i = 0; i < items.Count; i++)
        {
            currentItem = items.ElementAt(i);

            if (currentItem.RowNumber == row)
            {
                return currentItem;
            }

            if (currentItem.ItemType == EstimationItemType.Group || currentItem.ItemType == EstimationItemType.Part)
            {
                if (i < items.Count - 1 && items.ElementAt(i + 1).RowNumber > row)
                {
                    return FindItem(currentItem.Items, row);
                }
            }
        }
        return null;
    }
    private IEnumerable<EstimationItem> GetAllItems(EstimationItem item)
    {
        yield return item;
        foreach (var child in item.Items)
        {
            GetAllItems(child);
        }
    }
}
