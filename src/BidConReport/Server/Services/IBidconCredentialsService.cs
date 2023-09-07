using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Server.Services;
public interface IBidconCredentialsService
{
    Task<BC_DatabaseCredentialsDto?> GetAsync(string organizationId);
    Task UpsertAsync(BC_DatabaseCredentialsDto credentialsDto, string organizationId);
}