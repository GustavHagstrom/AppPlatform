using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Core.Enums.BidconAccess;

namespace AppPlatform.ViewSettingsModule.Components;
static class SampleEstimationFactory
{
    public static Estimation CreateSamepleEstimation()
    {
        var estimation = new Estimation
        {
            BidconId = "123",
            ConfirmationOfficer = "Test",
            Customer = "Test",
            Description = "Test",
            HandlingOfficer = "Test",
            Name = "Test",
            Place = "Test",
            NetSheet = new SheetItem
            {
                Description = "Root",
                RowType = (int)RowType.Group,
                Children = new List<SheetItem>
                    {
                        new SheetItem
                        {
                            Description = "Group",
                            RowType = (int)RowType.Group,
                            Children = new List<SheetItem>
                            {
                                new SheetItem
                                {
                                    Description = "Part",
                                    RowType = (int)RowType.Part,
                                    Quantity = 2,
                                    Unit = "st",
                                    Children = new List<SheetItem>
                                    {
                                        new SheetItem
                                        {
                                            Description = "Post",
                                            RowType = (int)RowType.LayeredItem,
                                            Quantity = 10,
                                            Unit = "st",
                                            LayerItemUnitCost = 100.55,
                                            LayerItemUnitAskingPrice = 200.1,
                                        }
                                    }
                                }
                            }
                        }
                    }
            }
        };
        SetSheetItemParentReferenses(estimation.NetSheet, null);
        return estimation;
    }
    private static void SetSheetItemParentReferenses(SheetItem item, SheetItem? parent)
    {
        item.Parent = parent;
        if (item.Children != null)
        {
            foreach (var child in item.Children)
            {
                SetSheetItemParentReferenses(child, item);
            }
        }
    }
}
