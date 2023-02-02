using BidConReport.SharedLibrary.Models;

namespace SharedLibrary.ExportPresentation.Layout;
public class GeneralInformationDefinition
{
    public GeneralInformationDefinition()
    {
        DescriptionValueItems = new List<CheckableItem<DescriptionValueItem>>
        {
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "Name", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "CreationDate", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "ExpirationDate", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "PrintDate", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "Version", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "Representant", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "Handläggare", Description = string.Empty, Value = string.Empty }),
            new CheckableItem<DescriptionValueItem>(true, new DescriptionValueItem { Type = "Currency", Description = string.Empty, Value = string.Empty }),
        };
    }
    public bool IsEnabled { get; set; } = true;
    public List<CheckableItem<DescriptionValueItem>> DescriptionValueItems { get; set; }
    public string FontSize { get; set; } = string.Empty;

}
