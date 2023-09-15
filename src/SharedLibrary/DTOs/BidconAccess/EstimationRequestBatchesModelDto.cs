namespace SharedLibrary.DTOs.BidconAccess;

public record EstimationRequestBatchesModelDto(IEnumerable<string> EstimationIds, BC_DatabaseCredentialsDto Credentials);