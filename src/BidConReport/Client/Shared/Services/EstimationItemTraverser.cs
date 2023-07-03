using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;

public class EstimationItemTraverser : IEstimationItemTraverser
{
    public EstimationItem? FindItem(Estimation estimation, int row)
    {
        var root = CreateRoot(estimation);
        return FindItem(root, row);
    }
    public IEnumerable<EstimationItem> GetAllEstimationItems(Estimation estimation)
    {
        foreach (var baseNode in estimation.Items)
        {
            foreach (var item in GetAllItems(baseNode))
            {
                yield return item;
            }
        }
    }
    private EstimationItem? FindItem(EstimationItem root, int row)
    {
        if (root.RowNumber == row)
        {
            return root;
        }

        for (int i = root.Items.Count - 1; i >= 0; i--)
        {
            var elementAtIndex = root.Items.ElementAt(i);
            if (elementAtIndex.RowNumber <= row)
            {
                return FindItem(elementAtIndex, row);
            }
        }

        return null;
    }
    private IEnumerable<EstimationItem> GetAllItems(EstimationItem root)
    {
        yield return root;
        foreach (var child in root.Items)
        {
            foreach (var item in GetAllItems(child))
            {
                yield return item;
            }
        }
    }
    private EstimationItem CreateRoot(Estimation estimation)
    {
        return new EstimationItem
        {
            Comment = string.Empty,
            DisplayedQuantity = string.Empty,
            DisplayedUnit = string.Empty,
            Id = Guid.Empty,
            ItemType = EstimationItemType.Group,
            Name = string.Empty,
            Quantity = double.NaN,
            RowNumber = -1,
            Tags = Array.Empty<string>(),
            Unit = string.Empty,
            UnitCost = double.NaN,
            Items = estimation.Items
        };
    }
}
