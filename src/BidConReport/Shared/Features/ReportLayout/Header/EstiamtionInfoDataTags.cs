namespace BidConReport.Shared.Features.ReportLayout.Header;
public record InfoTag(string Name, string Tag);
public static class EstiamtionInfoDataTags
{
    public static readonly InfoTag Name = new("Name", "{Name}");
    public static readonly InfoTag Description = new("Description", "{Description}");
    public static readonly InfoTag Currency = new("Currency", "{Currency}");
    public static readonly InfoTag CostBeforeChanges = new("CostBeforeChanges", "{CostBeforeChanges}");
    public static readonly InfoTag CreationDate = new("CreationDate", "{CreationDate}");
    public static readonly InfoTag ExpirationDate = new("ExpirationDate", "{ExpirationDate}");
}
