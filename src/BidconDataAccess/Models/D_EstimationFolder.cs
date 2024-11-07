namespace AppPlatform.BidconDatabaseAccess.Models;
public class D_EstimationFolder
{
    public int FolderNum { get; set; }
    public int ParentNum { get; set; }
    public required string Name { get; set; }
    public override string ToString() => Name;
}
