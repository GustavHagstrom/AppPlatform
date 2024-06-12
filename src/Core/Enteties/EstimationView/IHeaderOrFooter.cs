using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Core.Enteties.EstimationView;
public interface IHeaderOrFooter
{
    View? EstimationViewTemplate { get; set; }
    string EstimationViewTemplateId { get; set; }
    string Id { get; set; }
    string Value { get; set; }
}