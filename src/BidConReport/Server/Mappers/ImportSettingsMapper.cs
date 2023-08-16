using BidConReport.Server.Enteties;
using BidConReport.Shared.DTOs;
using Riok.Mapperly.Abstractions;

namespace BidConReport.Server.Mappers;
[Mapper]
public partial class ImportSettingsMapper
{
    //public partial EstimationImportSettings SettingToSetting(EstimationImportSettings settings);
    public partial EstimationImportSettings FromDto(EstimationImportSettingsDto dto);
    public partial EstimationImportSettingsDto ToDto(EstimationImportSettings settings);
}
