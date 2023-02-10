namespace SharedLibrary.ExportPresentation.Layout;
public class LayoutDefinition
{
    public LayoutDefinition()
    {
        LayoutOrder = new List<LayoutSectionType> 
        { 
            LayoutSectionType.Title,
            LayoutSectionType.GeneralInformation,
            LayoutSectionType.Price,
            LayoutSectionType.Table,
        };
    }
    public HeaderDefinition Header { get; set; } = new();
    public TitleDefinition Title { get; set; } = new();
    public GeneralInformationDefinition GeneralInformation { get; set; } = new();
    public PriceDefinition Price { get; set; } = new();
    public TableDefinition Table { get; set; } = new();
    public List<LayoutSectionType> LayoutOrder { get; set; }

}
