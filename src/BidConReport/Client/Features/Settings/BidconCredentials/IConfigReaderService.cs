using BidConReport.Shared.DTOs.BidconAccess;
using Microsoft.AspNetCore.Components.Forms;

namespace BidConReport.Client.Features.Settings.BidconSettings.BicdonCredentials;
public interface IConfigReaderService
{
    Task<BC_DatabaseCredentialsDto?> ReadCredentialsAsync(IBrowserFile browserFile);
}