using Syncfusion.DocIO.DLS;

namespace BidConReport.Shared.Models;
public class DbFolder
{
    public string Name { get; set; } = string.Empty;
    public List<DbFolder> SubFolders { get; set; } = new();
    public List<DbEstimation> DbEstimations { get; set; } = new();
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
}
