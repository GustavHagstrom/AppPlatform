namespace SharedLibrary.Models;
public class DbFolder
{
    public string Name { get; set; } = string.Empty;
    public List<DbFolder> SubFolders { get; set; } = new();
    public List<DbEstimation> DbEstimations { get; set; } = new();
}
