using Client.Shared.EstimationViewTemplate.Models;
using SharedLibrary.DTOs.EstimationView;

namespace Client.Shared.EstimationViewTemplate;

public class ViewTemplateMapper
{
    public ViewTemplate FromDto(EstimationViewTemplateDto sourceDto, ViewTemplate? destinationTemplate = null)
    {
        if (destinationTemplate is null)
        {
            destinationTemplate = new ViewTemplate { Name = sourceDto.Name };
        }

        throw new NotImplementedException();
    }
    public EstimationViewTemplateDto ToDto(ViewTemplate sourceTemplate, EstimationViewTemplateDto? destinationDto = null)
    {
        throw new NotImplementedException();
    }
}
