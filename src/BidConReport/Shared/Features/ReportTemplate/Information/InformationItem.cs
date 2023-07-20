using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate.Information;

public class InformationItem 
{
    public InformationItem(bool isEnabled, InformationType type, string title)
    {
        IsEnabled = isEnabled;
        Type = type;
        Title = title;
    }
    public InformationItem()
    {
            
    }
    public int Id { get; set; }
    public int InformationSectionId { get; set; }
    public bool IsEnabled { get; set; }
    public InformationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public string ValueCode { get; set; } = string.Empty;
}
