using AppPlatform.Server.Enteties.EstimationView;

namespace AppPlatform.Server.Services.EstimationView;
public interface IEstimationViewTemplateUpdater
{
    void Update(EstimationViewTemplate existing, EstimationViewTemplate updateSrc);
}