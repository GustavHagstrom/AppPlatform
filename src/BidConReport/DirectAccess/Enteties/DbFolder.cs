namespace BidConReport.DirectAccess.Enteties;
public class DbFolder
{
    public int FolderNum { get; set; }
    public int ParentNum { get; set; }
    public required string Name { get; set; }
    public required ICollection<DbFolder> SubFolders { get; set; }
    public required ICollection<DbEstimation> DbEstimations { get; set; }
    public IEnumerable<DbEstimation> GetAllEstimations()
    {
        return GetAllEstimations(this);
    }
    private IEnumerable<DbEstimation> GetAllEstimations(DbFolder folder)
    {
        foreach (var subFolder in folder.SubFolders)
        {
            foreach (var estimation in GetAllEstimations(subFolder))
            {
                yield return estimation;
            }
        }
        foreach (var estimation in folder.DbEstimations)
        {
            yield return estimation;
        }
    }
    public override string ToString() => Name;
}
