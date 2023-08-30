using BidConReport.Client.Shared.Services.EstimationReport.Models;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.DTOs.EstimationReportDtos;
public interface IReportSection
{
    Guid Id { get; set; }
    int Order { get; set; }
    [Range(1,12)]
    int ColumnsCount { get; set; }
    IEnumerable<Cell> Cells { get; }
}
