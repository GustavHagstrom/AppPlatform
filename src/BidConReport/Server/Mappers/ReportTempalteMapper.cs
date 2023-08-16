using BidConReport.Server.Enteties.Report;
using BidConReport.Shared.DTOs.ReportTemplate;
using Riok.Mapperly.Abstractions;

namespace BidConReport.Server.Mappers;
[Mapper]
public partial class ReportTempalteMapper
{
    public partial ReportTemplate FromDto(ReportTemplateDTO dto);
    public partial ReportTemplateDTO ToDto(ReportTemplate dto);
}
