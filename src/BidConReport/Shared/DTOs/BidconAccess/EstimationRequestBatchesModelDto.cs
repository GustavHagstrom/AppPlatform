namespace BidConReport.Shared.DTOs.BidconAccess;

public record EstimationRequestBatchesModelDto(IEnumerable<string> EstimationIds, BC_DatabaseCredentialsDto Credentials);