namespace SharedLibrary.ExportPresentation.Layout;
public class PriceDefinition
{
    public bool IsEnabled { get; set; } = true;
    public string PriceWithoutChangesDescription { get; set; } = string.Empty;
    public string ChangesDescription { get; set; } = string.Empty;
    public string PriceWithChangesDescription { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string Font { get; set; } = string.Empty;
    public string FontSize { get; set; } = string.Empty;
    public string FontWeight { get; set; } = string.Empty;
}
