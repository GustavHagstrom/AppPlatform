namespace AppPlatform.BidconDatabaseAccess.Models;
public class EstimationFolder
{
    public int FolderNum { get; set; }
    public int ParentNum { get; set; }
    public required string Name { get; set; }
    public override string ToString() => Name;
}
