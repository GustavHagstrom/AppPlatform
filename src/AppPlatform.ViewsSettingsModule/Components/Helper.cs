using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Core.Enums.BidconAccess;
using Microsoft.Extensions.Localization;

namespace AppPlatform.ViewSettingsModule.Components;
public class Helper(IStringLocalizer<Helper> Localizer)
{
    private Dictionary<SectionType, string> SectionTypeNames = new()
    {
        { SectionType.DataSection, Localizer["Data"] },
        { SectionType.SheetSection, Localizer["Tabell"] },
        { SectionType.PageBreakSection, Localizer["Sidbrytning"] },
    };
    public string GetSectionTypeName(SectionType sectionType)
    {
        return SectionTypeNames[sectionType];
    }
    public string GetSectionTypeName(ISection section)
    {
        if(section is DataSection)
        {
            return GetSectionTypeName(SectionType.DataSection);
        }
        else if (section is SheetSection)
        {
            return GetSectionTypeName(SectionType.SheetSection);
        }
        else if(section is PageBreakSection)
        {
            return GetSectionTypeName(SectionType.PageBreakSection);
        }
        throw new NotImplementedException();
    }
    public SectionType GetSectionType(ISection section)
    {
        if (section is DataSection)
        {
            return SectionType.DataSection;
        }
        else if (section is SheetSection)
        {
            return SectionType.SheetSection;
        }
        else if (section is PageBreakSection)
        {
            return SectionType.PageBreakSection;
        }
        throw new NotImplementedException();
    }
    public Estimation CreateSamepleEstimation()
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
