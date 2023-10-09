using SharedLibrary.Enums.ViewTemplate;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class SheetRow //Add to Dto and server 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int TopPadding { get; set; }
    public SheetRowType RowType { get; set; }

}
