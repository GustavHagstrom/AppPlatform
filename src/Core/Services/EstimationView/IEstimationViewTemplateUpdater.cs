using AppPlatform.Core.Enteties.EstimationView;

namespace AppPlatform.Core.Services.EstimationView;
public interface IEstimationViewTemplateUpdater
{
    void Update(EstimationViewTemplate existing, EstimationViewTemplate updateSrc);
}