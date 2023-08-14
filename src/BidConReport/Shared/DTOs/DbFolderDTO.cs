using BidConReport.Shared.DTOs;
using Syncfusion.DocIO.DLS;

namespace BidConReport.Shared.DTOs;
public class DbFolderDTO
{
    public required string Name { get; set; }
    public required ICollection<DbFolderDTO> SubFolders { get; set; }
    public required ICollection<DbEstimationDTO> DbEstimations { get; set; }
    public IEnumerable<DbEstimationDTO> GetAllEstimations()
    {
        return GetAllEstimations(this);
    }
    private IEnumerable<DbEstimationDTO> GetAllEstimations(DbFolderDTO folder)
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
