using BidConReport.BidconAccess.Enums;
using BidConReport.Shared.DTOs.EstimationReportDtos;

namespace BidConReport.Client.Shared.Services.EstimationReport.Models;

public class SheetSection : IReportSection
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Order { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public SheetType SheetType { get; set; }

}
