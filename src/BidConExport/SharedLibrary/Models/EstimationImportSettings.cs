using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models;
public class EstimationImportSettings
{
    //public int Id { get; set; }
    [Required]
    public string SettingsName { get; set; } = string.Empty;
    [Required]
    public string CostFactorAccount { get; set; } = string.Empty;
    [Required]
    public string CostBeforeChangesAccount { get; set; } = string.Empty;
    [Required]
    public string NetCostAccount { get; set; } = string.Empty;
    //[Required]
    public string HiddenTag { get; set; } = string.Empty;
    //public DateTime? ExpirationDate { get; set; }
    public List<string> StyleTags { get; set; } = new();
    public List<string> OptionTags { get; set; } = new();
    
}
